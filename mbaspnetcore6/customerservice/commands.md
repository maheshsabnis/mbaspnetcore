# Creating Repository

aws ecr create-repository --repository-name eksdemoecr --region us-east-2

# Reppsitory Name
472804039072.dkr.ecr.us-east-2.amazonaws.com/eksdemoecr

# Login to ECR

aws ecr get-login-password --region us-east-2 | docker login --username AWS --password-stdin 472804039072.dkr.ecr.us-east-2.amazonaws.com/eksdemoecr

# Tag the loal Docker Image to the Repository Name as follows

docker tag custserv:v1 472804039072.dkr.ecr.us-east-2.amazonaws.com/eksdemoecr:v1

# Push the Image to ECR

docker push 472804039072.dkr.ecr.us-east-2.amazonaws.com/eksdemoecr:v1

# Creating Cluster

# Use the Following URL for CloudFormation
https://amazon-eks.s3.us-west-2.amazonaws.com/cloudformation/2020-06-10/amazon-eks-vpc-private-subnets.yaml


# The Cluster.json file will be as follows

````json
apiVersion: eksctl.io/v1alpha5 // version
kind: ClusterConfig // kind: the reason for which the file created, ClusterConfig, means created for EKS cluster creation
metadata:
  name: EKS-node-Cluster // cluster name
  region: us-east-2 // region where the cluster is available

vpc:
  id: vpc-03ecef376733dafd3  // VPM id received from stack of CloudFormation
  cidr: "192.168.0.0/16" // CIDR address ranges
  subnets: // public and private subntes for the internal and external communications
    public:
      us-east-2a: // 
        id: subnet-0a3ae750f8584f38c
      us-east-2b:
        id: subnet-073b5f4a67284ff9a
    private:
      us-east-2a:
        id: subnet-0aa44995415e64590
      us-east-2b:
        id: subnet-0e58f64081a75a947

nodeGroups: // confoguration for the nodes (VMs) where yhe app will be deployed
  - name: EKS-public-workers  // node name
    instanceType: t2.medium // the category of VM
    desiredCapacity: 2 // take 2 VMs
  - name: EKS-private-workers
    instanceType: t2.medium
    desiredCapacity: 1 // take 1
    privateNetworking: true

````

# CRaete a Cluster using the following command
 - Command on windows
eksctl create cluster -f cluster.json --kubeconfig=c:\users\{user}\.kube\config

- Command in Linux and Mac
eksctl create cluster -f cluster.json --kubeconfig=~/.kube/config