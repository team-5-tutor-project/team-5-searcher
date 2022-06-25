FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /back
COPY . ./
RUN dotnet publish Back/TutorProject.Searcher/TutorProject.Searcher.Web/TutorProject.Searcher.Web.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 6001
ENV ASPNETCORE_URLS=http://+:6001
WORKDIR /back
COPY --from=build /back/out .
ENTRYPOINT ["dotnet", "TutorProject.Searcher.Web.dll"]