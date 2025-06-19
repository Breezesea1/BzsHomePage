# ——— 阶段 1：构建和发布项目 ———
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src", "./src"]
COPY ["BzsHomePage.sln", "./"]
RUN dotnet restore "BzsHomePage.sln"

COPY . .
WORKDIR "/src/src/BzsHomePage.Web"
RUN dotnet publish -c Release -o /app/publish /p:DefineStaticWebAssetEndpoints=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# 可选：配置环境变量
ENV ASPNETCORE_URLS=http://+:8888

# 暴露端口并设置入口
EXPOSE 8888
ENTRYPOINT ["dotnet", "BzsHomePage.Web.dll"]
