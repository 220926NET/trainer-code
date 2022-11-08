# Docker
Docker is a containerization platform that allows developers to package their application alongside with their dependencies in one convenient place/package. It allows software to be run independently of os/platform

## If you are given an empty machine (not even an OS) with internet connection and were to run your API there...
1. Install an OS
2. Install .NET SDK
3. Install code editor
4. Install git
5. download your source code (git clone)
6. Build your application
7. Finally we run it

## Now imagine, if you had a virtual machine on the cloud and wanted to run your application
At the very least you'll have to
- get a runtime
- download artifact 
- and run it

### So what if... we can package our app alongside with all our dependencies (not just the libraries, but things like runtime) and put a pretty button for someone to push?
    - That is, in essence, docker container.
    - Docker allows for rapid scaling and freedom from platforms

## Containerization
Is a way to provide *uniform environment* to run our app regardless of whichever machine we end up in.

## Terms
- docker engine
    - is the daemon(software that sits in the background idly and wait for work) that actually runs all docker commands

- dockerfile
    - Is a file of instructions to docker engine in order to create a file system (or Image) that has everything you need to run your app (your app, your dependencies, your runtime, etc.)
    - in dockerfiles, we put stuff like which run time to use, how to build our application, and what to do when someone runs the image

- dockerignore
    - gitignore file for dockerfile

- (Docker) Image
    - Is a **file system** that contains your application artifacts, your dependencies, runtime, reverse proxy, etc, whatever you need to run your application

- Tag
    - Tag is a way to differentiate between different versions of the same image. 
    We can use tag to discern between different builds (ie does this image have the latest changes?). Other times people use it to provide different versions to users (such .NET SDK docker image)

- Container
    - Virtualized OS/Software
    - Resources are dynamically allocated (in VM's resources are statically allocated)
    - It's smaller (in 100's of Mb's and maybe a few Gb's)

- Image Registry (Docker Hub)
    - Is a place to upload/download/share images. Docker hub is one of the biggest image registries for docker images, and this is like what github is to git.

- both containers and virtual machines achieve the same goal -> being able to run isolated uniform environments regardless of host machine


## Docker CLI Commands
- To run local images:
    -`docker run image-name`
    - `-d` "detached" runs the container in the background
    - `-p host:container` to map container port to host machine
    - `docker run -d -p 8080:8080 aschil/snake`
- To see all your local images:
    - `docker image ls`
- to remove your local image
    - `docker image rm image-name-or-image-id`
- the above two commands are the same for containers as well
    - `docker container ls`
    - `docker container rm container-id`
- when in doubt, `docker resource-name --help`
- To download image from docker hub
    - `docker pull image-name`
- To upload image to docker hub
    - `docker push image-name`
- To build our image from dockerfile
    - `docker build`
    - `docker build relative-path-to-folder-containing-dockerfile -t dockerhubusername/imagename:tag-name`
    - ex: `docker build . sminseonong/pokestorage:latest`

## Docker Compose
Is a way to coordinate multiple containers together