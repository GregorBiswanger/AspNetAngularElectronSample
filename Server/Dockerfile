FROM electronuserland/builder
RUN apt-get update && \
     apt-get install -y nodejs && \
     apt-get install -y gpg && \
     wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg && \
     mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/ && \
     wget https://packages.microsoft.com/config/ubuntu/18.04/prod.list && \
     mv prod.list /etc/apt/sources.list.d/microsoft-prod.list && \
     chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg && \
     chown root:root /etc/apt/sources.list.d/microsoft-prod.list && \
     apt-get update && \
     apt-get install -y apt-transport-https && \
     apt-get update && \
     apt-get install -y dotnet-sdk-5.0 && \
     dotnet tool install ElectronNET.CLI --tool-path /tmp