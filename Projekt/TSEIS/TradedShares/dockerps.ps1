param([string]$name = "lostreidiotos/tsbackend") #Must be the first statement in your script

docker build -t $name . 
docker push $name