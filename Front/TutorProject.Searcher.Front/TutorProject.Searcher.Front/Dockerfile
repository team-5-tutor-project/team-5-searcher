FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Front/TutorProject.Searcher.Front/TutorProject.Searcher.Front/TutorProject.Searcher.Front.csproj .
RUN dotnet restore TutorProject.Searcher.Front.csproj
COPY Front/TutorProject.Searcher.Front/TutorProject.Searcher.Front .
RUN dotnet build TutorProject.Searcher.Front.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish TutorProject.Searcher.Front.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Front/TutorProject.Searcher.Front/TutorProject.Searcher.Front/nginx.conf /etc/nginx/nginx.conf