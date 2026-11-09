# Contributing

Thanks for wanting to help. SimpleDateTimeProvider is small on purpose, so the best changes are usually small too.

## Before you start

- **Found a bug?** Open a [bug report](https://github.com/stphnwlsh/SimpleDateTimeProvider/issues/new?template=bug_report.yml).
- **Got an idea?** Open a [feature request](https://github.com/stphnwlsh/SimpleDateTimeProvider/issues/new?template=feature_request.yml) before writing much code, so we can agree it fits before you spend your weekend on it.
- **Found a security problem?** Follow the [security policy](SECURITY.md) instead of opening an issue.

## Build and test

You need the [.NET 10 SDK](https://dotnet.microsoft.com/download). Then:

```sh
dotnet build
dotnet test
dotnet format --verify-no-changes
```

The build treats warnings as errors, and CI fails if line coverage drops below 95%. To check coverage the same way CI does:

```sh
dotnet test -p:CollectCoverage=true -p:Threshold=95 -p:ThresholdType=line -p:Include="[SimpleDateTimeProvider]*"
```

### The .NET Framework tests

On Windows the unit tests also target .NET Framework 4.8, which runs the .NET Standard 2.0 build where most of its users are. On Windows:

```sh
dotnet test tests/SimpleDateTimeProvider.Tests.Unit --framework net48
```

Not on Windows? CI runs them on every pull request, so you'll find out there.

## The rules

- **.NET Standard 2.0 is the floor.** The library compiles as C# 7.3 for it, so no newer syntax in `src/`. The `.editorconfig` already knows this.
- **No dependencies.** The package has none, and it's going to stay that way.
- **Some test packages are locked to their current major version.** They're what run the tests on .NET Framework 4.8, and a new major is where support for old frameworks tends to go. Dependabot skips their majors (see `.github/dependabot.yml`). To move one up, check its new version still targets .NET Framework 4.6.2 or later, bump it in a pull request and let CI's .NET Framework job have the final say.

## Pull requests

1. Fork the repository and branch from `main`.
2. Make your change, with tests for anything that behaves differently.
3. Run the build, tests and format check above.
4. Open a pull request and fill in the template.

`main` is protected, so every change goes through a pull request with green checks.

## Releases

You don't need to do anything. Dependabot opens one pull request on the 15th of each month, and on the 1st the Build Pipeline publishes to NuGet if anything in `src/` has changed since the last release, then creates a matching GitHub release. Changes only to tests, samples or the pipeline wait for the next change that's worth installing.

For the maintainer:

- **Out-of-cycle release:** run the Build Pipeline from the Actions tab with `release`, untick `dry-run`, and tick `force` if nothing in `src/` has changed.
- **Rehearsal:** run it with `dry-run` ticked. It builds, tests, packs and logs in to NuGet, but publishes nothing.
- **Publishing** uses NuGet [trusted publishing](https://learn.microsoft.com/nuget/nuget-org/trusted-publishing), so there's no API key to expire. It needs the `NUGET_USER` repository secret and a trusted publishing policy on nuget.org for this repository's `build-pipeline.yml`.
