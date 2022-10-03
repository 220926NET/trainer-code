# git

Git is a version control system, to be more precise, it's a distributed version control system, meaning everybody as their own copy of the repository

Basically, git is a way for software devs to back up our work and collaborate with others

## source code
Source code is your program

## Repository
Git repository or repo is source code plus the history of changes you've made

## Basic Git Workflow
1. make changes
2. Add to the staging area using git add file-or-folder-name
3. Commit with a meaningful message (For future you and your teammates) using git commit -m "message here"

- to view your staging area, use git status

## Working with Remote Repositories
- Add a new remote repository to your local repo by executing `git remote add nickname repo-url`
- Push your updates by `git push`
- Pull the updates from remote repo by `git pull`
- Download/Copy the new remote repo to your local machine by running `git clone repo-url` (this is the way to go, if you already have remote repository set up)

## Gitignore
.gitignore file is a file telling git to ignore certain files/folders and do not track/add these to the repository.
`dotnet new gitignore` at the root of your repository

## Branching
- `git branch` : displays all your LOCAL repository branches
- `git checkout branch-name`: Move to a different branch. Make sure you don't have any uncommitted changes
- `git log`: gives you the commit history of the particular branch
- `git branch branch-name`: creates a new branch
- `git branch branch-name commitId`: creates a new branch from a particular commit
- `git checkout -b branch-name`: this will create a new branch, and automatically check out to the branch
- `git merge b`: merge commits from b branch into your current branch
- `git branch -d branch-name`: to delete branch

## Merge Conflict
This is git's way of saying that there are changes occurred in the same location of the same file, and it needs human intervention/review to see what to keep.
In order to resolve merge conflicts, review them and then choose which to keep, then add/commit.

## Oops, I committed and pushed stuff to remote repository I didn't mean to
1. `git rm --cached the-file-you-want-it-gone`: This is remove the file from the git repository, while leaving the file in the file system.
1a. `git rm -r --cached folder-you-want-it-gone` to remove folders from git repository
2. Fix your gitignore
3. add and commit your changes
4. push the changes to your remote repository
5. profit