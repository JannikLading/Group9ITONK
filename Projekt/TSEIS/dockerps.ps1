param(  [Parameter(Mandatory)][string]$name, 
    [Parameter(Mandatory)][string]$project  ) 

docker build -t $name -f ".\$project\DockerFile" . 
docker push $name