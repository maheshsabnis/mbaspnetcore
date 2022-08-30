# The Configuration File for the Microservice

# Additional Steps for Apple M1 Chip
# Inform the DOcker that although the Docker on M1 Chip create
# image for ARM64 as well as X86 Intel Chip

ARG ARCH=amd64
ARG TAG=6.0-bullseye-slim-$ARCH

# 1 to 9 Step are Common for Intel/ARM chips
# 1. Get the Base Image for Application Framework 
# (This is the Linux Image for ASP.NET Core)
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# 2. Set the Working Directory on the Image 
# (The Path from where the Execution will Start)
WORKDIR /source
# 3. Copy the Project File to the Target in Image 
# so that all dependencies for the Current project will  
# will be created in the Image after the Image is Build
COPY ./customerservice.csproj .
# 4. (VERY-IMP) Run the Command to Restore all the Dependencies as well 
# application Framework in Image
# This will By default take the .csproj file path and restore
# all packages
RUN dotnet restore

# 5. COPY all Files from the Current Folder to the Image Working Directory
COPY . .
# 6. Build all these file inside the Image Once 
# This is optional because when the App is run it will buold first

# RUN dotnet build  customerservice.csproj -c Debug -o /source/out

# 7. Make the Image Ready for Execution
# 7.1 Set the Application Framework that is chosen in Step 1 ready to Host
# 7.2 COnfigire the App Path from where the application code build libraries
# will be taken for execution
# 7.2 Set the Out Path for Build so that the Applciation code will be
# ready to execute aka ENTRYPOINT
# build and publish the application so that it is ready for 
# release in the image and the --no--restore, wil make sure that
# all dependencies those are install are Production ready
# Thsi will connect to https://www.nuget.org to read Production dependencies
WORKDIR /source/
RUN dotnet publish -c release -o /app --no-restore

# 8. EXPOSE the PORT for Communcation to API Hosted in Image
# This is Ready-to-USe ASP.NET Core 6 Application Farmework Image 
# For Linux when out ASP.NET COre 6 API will be loaded and executed
FROM mcr.microsoft.com/dotnet/aspnet:$TAG
WORKDIR /app
# 9. SET the ENTRYPOINT, that will actually Load Application Library
# The Production Build accessible from /app folder inside the /source
# folder
COPY --from=build /app ./
# in Hosting Environment and stat accepting requests  
# Expose the PORT
EXPOSE 80
# INternally this will call dotnet run command
# That will load ustomerservice.dll inside the ASP.NET Core Runtime
# in the dotnet.exe inside the Image 
ENTRYPOINT ["dotnet", "customerservice.dll"]
