# Docker image ARGS
ARG BASE_IMAGE_REPO=mcr.microsoft.com
ARG BASE_IMAGE_BUILD=dotnet/sdk
ARG BASE_IMAGE_BUILD_TAG=6.0-alpine
ARG BASE_IMAGE_RUNTIME=dotnet/aspnet
ARG BASE_IMAGE_RUNTIME_TAG=6.0-alpine

# Setup Build Image
FROM ${BASE_IMAGE_REPO}/${BASE_IMAGE_BUILD}:${BASE_IMAGE_BUILD_TAG} AS build

# Build, Test and Publish ARGS
ARG VERSION_PREFIX=1.0.0.0
ARG VERSION_SUFFIX
ARG ENVIRONMENT=docker

# Build, Test and Publish ENVS
ENV DOTNET_ENVIRONMENT=${ENVIRONMENT}

WORKDIR /sln

# Dotnet Restore
COPY ./*.sln ./NuGet.config  ./
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
COPY tests/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p tests/${file%.*}/ && mv $file tests/${file%.*}/; done

RUN dotnet restore -v minimal

# Bust Cache
ARG CACHE_BUST 1

# Copy Remaining Files
COPY . .

# Dotnet Build
RUN dotnet build --no-restore -c Release -v minimal -p:VersionPrefix=${VERSION_PREFIX} -p:VersionSuffix=${VERSION_SUFFIX}

# Dotnet Test
FROM build AS test
RUN dotnet test --no-restore --no-build -c Release -v minimal -p:CollectCoverage=true  -p:CoverletOutput=../results/ -p:MergeWith="../results/coverage.json" -p:CoverletOutputFormat=opencover%2cjson -m:1

FROM scratch AS coverage
COPY --from=test /sln/tests/results/*.xml .

# Dotnet Pack
FROM build AS pack
ARG VERSION_PREFIX
ARG VERSION_SUFFIX
RUN dotnet pack ./src/**/*.csproj --no-restore -c Release -v quiet -o nuget -p:VersionPrefix=${VERSION_PREFIX} -p:VersionSuffix=${VERSION_SUFFIX}

FROM scratch AS nuget
COPY --from=pack /sln/nuget/* .