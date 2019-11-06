dotnet publish -c Release
docker build -t keepr1 ./bin/Release/netcoreapp3.0/publish
docker tag keepr1 registry.heroku.com/zkeepr/web
docker push registry.heroku.com/zkeepr/web
heroku container:release web -a zkeepr