param(  [Parameter(Mandatory)][string]$name, 
    [Parameter(Mandatory)][string]$project  ) 

docker build -t $name -f ".\$project\DockerFile" . 
docker push $name

#Example
#C:\IKT\6. semester\ITONK\Group9ITONK\Projekt\TSEIS>.\dockerps.ps1 -name "lostreidiotos/tradedshares" -project "TradedShares"