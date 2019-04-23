FROM microsoft/dotnet:2.1.2-aspnetcore-runtime-alpine3.7

COPY dist .

EXPOSE 64861

CMD ["dotnet", "BookStore.Api.dll"]