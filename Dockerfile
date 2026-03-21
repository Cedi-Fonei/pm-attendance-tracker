# https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=linux&pivots=dotnet-10-0#create-the-dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /App
COPY --from=builder /App/out .
ENTRYPOINT ["dotnet", "Attendance Tracker.dll"]
