# Cloud Concepts
Go through the [Azure Fundamentals: Describe cloud concepts Learning Path](https://learn.microsoft.com/en-us/training/paths/microsoft-azure-fundamentals-describe-cloud-concepts/) and answer the following questions in your own words (no copy paste from internet)

- What is Cloud Computing?
    - purchasing services from csp (cloud service providers) and using their infrastructure/hardware, etc.
    - The remote accessing and delivery of computing resources such as vm, dbs, storages, and processing over the internet
- What are benefits of cloud computing?
    - allows you to scale performance remotely, you're able to add more storage, cpu without having to buy more hardware, scale efficiently/infinitely/flexibly
    - You only pay for what you use
    - robust infrastructure/reliability of services(Service Level Agreement (SLA): 99%, 99.9% 99.99%)
    - better security/better practices
- Tell me about different types of scaling (vertical vs horizontal)
    - Vertical : adding cpu/memory to an already existing one or replacing it with a more capable one
    - Horizontal : increasing of actual instance
- What's the difference between public and private cloud?
    - public cloud is hosted by 3rd party, sharing infrastructure between different customers
    - private cloud is a customer having a sole access to the infrastructure whether it is hosted by themselves, or 3rd party provider  
- What is IaaS? When would you use that? What's an example of IaaS?
    - Infrastructure as a Service is a essentially renting a hardware in cloud data center and what you do is up to you
    - AWS EC2(elastic compute cloud), Azure VM(virtual machine)
    - CSP takes care of Physical maintenance of machines, security of area, electricity, connectivity to internet
    - You are responsible for.. OS, software, hosting, load management, configuration, update, etc.
- What is PaaS? When would you use that? What's an example of PaaS?
    - Platform as a Service is the middle ground between IaaS and SaaS
    - You have complete development environment control, but you don't have to maintain infrastructure
    - Analytics, BI, Azure Sql Server, Azure App Service, AWS Elastic Beanstalk (same as Azure App Service)
    - With PaaS, you get IaaS + the software infrastructure (hosting, server, load balancing, etc.)
    - you're still responsible for ... your data, your code/service/patches
- What is SaaS? When would you use that? What's an example of SaaS?
    - Software as a Service : where cloud company will offer software as well as infrastructure and platform
    - PaaS + software 
    - Microsoft 365, Email, Adobe Creative Cloud, Hackerrank, etc. Web Application that provides some service

![Different Service Levels](https://saeedtasbih.blog/wp-content/uploads/azure-management-responsibility.png)
### Bonus Questions
- Which cloud providers are there right now, other than Azure?
    - Azure, AWS, Vultr, GCP, IBM Cloud, Alibaba Cloud, Oracle Cloud, MacStadium(apple products) etc.
- Which certifications do they offer?
    - AWS, Azure, GCP, IBM Cloud offers various certifications
    - AWS: Certified Cloud Practitioner, Certified Cloud Solutions Architect
    - Azure: AZ-900 (Azure Fundamentals), DP-900 (Data Fundamentals), a bunch of others... such as Developer Associate (AZ-204), Microsoft Certified: Azure Fundamentals, Microsoft Certified: Security, Compliance, and Identity Fundamentals, Microsoft Certified: Azure AI Engineer Associate, Microsoft Certified: Azure for SAP Workloads Specialty
    - GCP: Cloud Digital Leader(their foundational cert)
    - IBM Cloud : IBM-Certified Associate, Certified Specialist, Certified Architect
    - [Could Tutorial](https://www.youtube.com/playlist?list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3)
    - Microsoft practice exams
    - CloudGuru, PluralSight
    - Udemy, Coursera, EdX, MooC

# DevOps
Use google(or your favorite search engine) and answer the following question in your own words
![DevOpsGraphic](https://imgs.search.brave.com/9MbcVWavcemLvqh9vvxji_No0vVRJDuzMjDO4xujRg8/rs:fit:1200:598:1/g:ce/aHR0cHM6Ly9ibG9n/cy52bXdhcmUuY29t/L21hbmFnZW1lbnQv/ZmlsZXMvMjAyMC8w/My8yMDIwLTAzLTAy/XzE0LTE4LTU3LnBu/Zw)
- What is DevOps?
    - DevOps is a set of practices and cultural philosophy that integrates the processes between dev and IT team
- What problem is it solving?
    - Dev teams and Ops teams had communication issues, 
    - it allows quick development of applications and services
    - incorporates the dev and ops processes to continual feedback loop
- Why is it so popular?
    - It leads to faster production cycle, quicker bug fixes, saves company time/money, increases customer satisfaction

- What is CI (Continuous Integration)?
    - CI : when you push to central repository, it will automatically builds and test, and in general, make sure that the code you're pushing is quality. CI can react on PR's, pushes, etc. and will ensure the coding standard of the company. It helps the reviewer by doing some of the routine tasks for them.
- What is Continuous Delivery?
    - it's an process where we automatically prepare the artifacts/deliverable so it's ready for production
    - can also push to testing
- What is Continuous Deployment?
    - Continuous Delivery + deployment 
    - similar to c. delivery except, it will also automatically deploy to an environment
    - can also have deployment strategies set up to help you with production deployment 

- Zero Downtime Deployment: is when you're able to put in new pieces of software and update w/o any downtime, being able to push new features to a live software
    - There are different strategies : Blue green deployment, etc.

- What are benefits of using CI/CD?
- What is a YAML file? How do we use it in CI/CD context?
    - configuration file for agents/runners that tells the machines what to do
    - YAML is a popular programming language because it is human-readable and easy to understand. It can also be used in conjunction with other programming languages. Because of its flexibility and accessibility, YAML is used by the Ansible automation tool to create automation processes, in the form of Ansible Playbooks.
- What are some tools available to configure CI/CD pipelines?
    - Gitlab, Jenkins, AWS Codebuild/codepipeline, Azure DevOps, **Github Actions**

- What is static code analysis?
- Why do we use static code analysis tools, such as sonar cloud?
    - Run tests on not running code to 
        - *To make sure it's up to company coding standard*
        - Data flow analysis
        - Taint Analysis for any vulnerabilities
- What is code coverage, why is it important?
    - Code Coverage is a percent of code that is covered by automated tests
        - it helps you spot problems
        - helps with better code writing (you have to write testable code)