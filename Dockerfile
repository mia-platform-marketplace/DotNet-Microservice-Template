##########################################################################
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 3000
ENV ASPNETCORE_URLS=http://*:3000

##########################################################################
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY src/DotNetCore_Template/DotNetCore_Template.csproj .
RUN dotnet restore DotNetCore_Template.csproj
COPY . .
WORKDIR /src/.
RUN dotnet build "DotNetCore_Template.csproj" -c Release -o /app/build

###########################################################################
FROM build AS publish
RUN dotnet publish "src/DotNetCore_Template/DotNetCore_Template.csproj" -c Release -o /app/publish

##########################################################################
LABEL maintainer="%CUSTOM_PLUGIN_CREATOR_USERNAME%" \
      name="%CUSTOM_PLUGIN_SERVICE_NAME%" \
      description="%CUSTOM_PLUGIN_SERVICE_NAME%" \
      eu.mia-platform.url="https://www.mia-platform.eu" \
      eu.mia-platform.version="0.1.0" \
      eu.mia-platform.language="c#" \
      eu.mia-platform.framework=".net core 3.1"

##########################################################################
FROM base AS final
WORKDIR /app

ARG COMMIT_SHA=<not-specified>
RUN echo "%CUSTOM_PLUGIN_SERVICE_NAME%: $COMMIT_SHA" >> ./commit.sha

COPY --from=publish /app/publish .

CMD ["dotnet", "DotNetCore_Template.dll"]
