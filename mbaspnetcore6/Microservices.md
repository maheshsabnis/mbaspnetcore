# Programming and Working with Microservices

1. Pre-Requisites
    - We need OS supporing Hardware Virtualization
        - Do this from BIOS
    - If using Windows 10 or 11, Install Hypert-V
        - Take OS Updates
        - Controle Panel --> Program and Features --> Turn WIndows Features On/Off --> Select Checkboxes for Hyper-V, Containerization, adn Windows SubSystem Form Linux (WSL 2.0)
        - Download Docker Desktop for Windows and then Install it
            - If gives Warning for WSL 2.0, then Download and Install WSL 2.0 Seperately from the Link of Warning Message
            - Aftre Installing DOcker DesktopGo to Settings and install Kubernetes
                - Note: There is Checkbox for instaling Kubernese is already checked while installing Docker Desktop
    - If using Ubuntu then p[lease follow Docker Documentation from Docker.io web site
    - If using MacBook, then Directly install Docker Desktop

    - Create an Account on Docker.io or https://hub.docker.com/
2. Docker Commands
    - https://docs.docker.com/engine/reference/commandline/docker/

    - Login on DOcker Reppository, i.e. hub.docker.com
        - docker login
            - This wwill open the Docker HUB portal and will ask for credentials
            - OR dirctly login from the Command Prompt (or GuitBash) from Windows and Terminal windoe from the Linux and MAc MAchine
        - docker logout
            - To logout

    - List all Images currently created locally
        - docker images
    - Creating an Image
        - The Path from where the COmmand for Creating Image Runs MUST have following two files
            - Dockerfile
                - Contains All Steps to Take Base Imge that has Application Runtime Framework and then steps to copy deployment files to this image and also for copying all depednencies in the image or Installing Dependencies directly inside the image
                - There exist a step to expose PORT from Image and hence from the Container
                - There exist a Step that contains COMMAND-TO-RUN the application from the image 
            - .dockerignore
                - Contains paths for all thos folder which we do not want to copy inside  image
                    - e.g.
                        - /bin
                        - /obj
            - Command to Create OR Build an image (Intel, ARM Chips)
                - docker build . -t [IMAGE-NAME]:[TAG]
                    - -t is for tag
                    - IMAGE-NAME, the name of the imahe always in lowerr-case
                    - TAG, the specific Version identification for the image
                - e.g.
                    - docker build . -t myimage:v1    
                - If using  MacBook with M1 Chip, then commadn will be
                    - docker build --pull --build-arg ARCH=arm64v8 -t IMAGE-NAME]:[TAG] .
            
                        
            - Command to Run the Docker Image in the Container
                - docker run -p [LOACL-MACHINE-PORT]:[PORT-EXPOSED-BY-IMAGE] --name=[CONTAIN R-NAME] [IMAGE-NAME]:[TAG]
                - LOACL-MACHINE-PORT: The PORT of the Localmachine that will connect to PORT exposed by image hence by the container
                - PORT-EXPOSED-BY-IMAGE: PORT exposed by images, this is mentioned in Dockerfile
                - --name: The Name of the Container that will host the image
                - CONTAIN R-NAME: This is set by us, otherwise the Docker Engine will sett the container name

            - List all Containers
                - docker ps
            - List all containers those are currently running
                - docker ps -a
            - PUshing an Image to Docker Hub (Other repositories are Azure Container Registry (ACR), AWS Elastic Container Registry (ECR))
                - Login on Repopsitory
                - Tage image to the repository USer Name
                    - docker tag [IMAGE-NAME]:[TAG] [REPOSITORY-USER-NAME]/[IMAGE-NAME]:[NEW-TAG]
                    - e.g.
                        - use name is mast007, image name is myimg and tag is v1

                        - dokcer tag myimg:v1 mast007/myimg:v1
                - PUSH newly tagged image to docker hub
                    - docker push [REPOSITORY-USER-NAME]/[IMAGE-NAME]:[NEW-TAG]
                    - e.g.
                        - docker push mast007/myimg:v1
            - Stopping Container
                - docker stop [CONTAINER-NAME OR CONTAINER-ID]
            - Removing Container
                - docker rm [CONTAINER-NAME OR CONTAINER-ID]
            - Removing Image
                - Make sure that the COntainer that is using the image is stopped and removed
                - docker rmi [IMAGE-NAME:TAG OR IMAGE-ID]

- If running multiple Microservice, then use one of the following
    - The 'Docker-Compose' facility
         - An Infrstructure provided by docker engine to run Multiple Docker Containers at a time, good in case of 'On-Premises' application, the Local Environment (NOT RECOMMENDED in PRODUCTION for large apps)
         - This provides the CPU, Memory, Storage, and Network respurces for all containers to run all Microservices
         - Instlled along with Docker Desktop
         - Commands
                - Create a docker-compose.yml file and configure all services in it
                - Run the folowing command to run all microservices form the pather where docker-compose.yml is present
                    - docker-compose up                   
                - Run the following command to relese all resources (CPU, Memory, Netwoking, and Storage)
                    - docker-compose down        
    - Use  Kubernetes aka K8s
          - A Cluster Management Service for Microservices
          - Recommended in Production 
            - Local Kubernetes Service Installed with Docker Desktop
            - Minikube
                - Local K8s for Learning and Testign Microservice apps
            - MicroK8s
                - Provided by Ubuntu Community
                - Considered for Production
            - Recommended for Large Scale Enterprise Microservice Apps in Production 
                - Microsoft Azure Kubernetes Service (AKS)
                - Amazon Elastic Kubernetes Serice (EKS)
                - Google Kubernetes Serice(GKS)    
                                            
# Communication Across Microservices
- Use the Message Broaker
    - RabbitMQ
    - Azure Service Bus
    - AWS SImple Messaging Service

- Using the RabbitMQ
    - DOewnload it image
        - docker run -d --hostname my-rabbitap --name emessage-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management
    - 15672: PORT on which the Messaging Service is Running
        - http://localhost:15672
                - A DAshboard or RabbiotMQ Managemtn Tool
                - The 'guest' is user name
                - The 'guest' is password             
    - 5672: The PORT over which the sender will send data to RabbitMQ and the receiver will receive data from it
- USing RabbitMQ with ASP.NET Core
    - RabbitMQ.Client package   
    - Add a logic in Publisher Applicaiton to Subscribe to the Rabbit MQ and pass message to it

    - In Receiver Application create a 'BackgroundService'
        - This service will subscribe to the Queue and once the message is avaialble in it, it will read message from the Queue      
        - USe 'BackgroundService' base class to create background service

- Microservices Best Practices
    - DO not use Database Image in Production
           - Instead use Database Instance on Cloud
    - If using Inrastructure Service e.g. Messaging, Caching, etc.
            - Make a Wise decicion, recommandations are use Cloud-BAsed Infra.
            - Messaging
                - Azure Service Bus
                - AWS SQS Messaging Service
                - AWS MQ or AWS SNS
                - RabbitMQ Cloud Service
            - Caching
                - Redis Cache         


# Microservice Deployment Platforms for Production
- Use Kuberneres
    - AKA K8s, used for automating the scaled deployment for Microservices based apps
    - Developed by Google and now available as a part of
        - Cloud Native Computing Foundation (CNCF)
- Physical Core Concepts
    - Cluster
         - A COllection of Multiple Nodes present for deployment of Microservices based Apps
            - Managed by K8s with Networking
            - The Networking management varies for On-Premised and Cloud Provider K8s Services
    - Node
         - A Machine that contains Deployment in PODs
         - COntains a Static IP for Communication and Contains the Cluster IP with Internal ROute Table Managed K8s   
    - POD
         - A Logical Grouping of Containers those Contains Microservices Images
         - Accepts the request Over the Port Exposed by the Container or set by the K8s based on COnfiguration
    - Container
         - This contain an Image of Microservice                                      
- Kuberbetes Providers
    - On-Premises
        - Docker-Desktop
            - WIndows, Mac, Linux
        - Minikube
            - WIndows, Mac, Linux
        - MicroK8s
            - Mac an d Linux
            - Used for Production
    - On-Cloud, for High-Available, Scalable, Mission Critical Apps with No-or-Zero Downtime
        - Microsoft Azure Kubernetes Service (AKS)
        - AWS Elestic Kuernetes Service (EKS)
        - Google Kubernetes Service (GKS)     

    - Services Offered by Kubernetes
        - API Server
            - USed top manage the Cluster with All PODs
            - Schedular
                - Used to manage PODs execution with Networking and Replicas using API Service
        - Additional Services
            - DNS Configuraion, VERY IMPORTANT
                - Used Manage various IPs for Communication
                    - IP Configurations
                        - ClusterIP
                            - Exposes the service on a cluster-internal IP.
                            - USed to make the service available anf accessible only within the Cluster. This is Default. 
                        - NodePort
                            - The service is exposed on each node's IP Address at static IP
                            - The Service can be directly accessed using the Node IP and the Port assigned by the COntainer by the POD in that Node
                            - e.g.
                                - If Node IP is 3.10.50.30 and PORT is 31106
                                - Then the Srevice will be accessible using the Following URL
                                    - http://3.10.50.30:31106/api/MyCOntrollers
                            - THe Request will be avccepted by the NodePort and then will be ROuted to the POD and the COntainer in it over a ClusterIP. The K8s mnagaes the RouteTable for this internally       
                        - LoadBalancer (ONLY-FOR-CLOUD)
                             - USed for exposing Services Exrternally by the Cloud Provider
                             - This is a Load Balancer managed by Cloud Provider to Accept Requests and process them by delivering the request to the Cluster using Route Table Managed INternally   
            - Ingress Controllers
                - Used for Managing Gateways
                - Other Gateways Services available e.g. Istio

- Process of Deployment
    - Create API Application
    - Create a Docker Image
    - Make Sure that the API runs in Image
    - Login on the Repository (Docker-Hub, AWS Elestic Container Repository, Azute COntainer Repository)
        - Make sure that the AWS ECR and Azute ACR are created first
        - If using Docker-Hub then make sure that you have login on Hub
    - Tag the Image to the Repopsitory Name
    - Push Image to repository
    - Create Deployment.yaml file for POD, Container, and Resource configuration
    - Create Service.yaml file for Service COnfiguration with Communication Port e.g. ClusterIP, NodePort, or LoadBalancer
    - Deploy Deploymenyt.yaml and then Service.yaml
        - Note: You can write Deployment and Service configuration in Same yaml file
    - Access the Service  
                
