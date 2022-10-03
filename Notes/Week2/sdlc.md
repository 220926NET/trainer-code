# Software Development Life Cycle (SDLC)

The process of planning, creating, deploying, designing, and maintaining of software application.
Few different styles: Agile, Waterfall, Lean, etc.

Steps:
- Planning: Getting ideas, what do you want this application to do?
- Analyze: Breaking the ideas down into components 
- Design: Figuring the structure necessary (would involve things like designing db's, architecture of application, UI/UX, how to test)
- Create: You actually write the code
- Test: Verify that the code you wrote works (Debugging, Unit testing, integration testing) 
- Deploy: Hosting, release it into the wild, making it available for customer's/client's use
- Maintain: fix any bugs that come up, perhaps qol updates, etc.


## Styles

### Waterfall
- One of the oldest methodology
- Originated from factories, manufacturing industry.
- Waterfall goes through each step exactly once.
- This means that waterfall is 
    - you plan a lot at the beginning
    - produce the final product in one go
    - very rigid 

### Agile (industry standard)
- We want to move quickly to changing business requirements, changing industry trends, and also be able to provide continuous updates to the software, maintain it easier, and make it scale easier

### Scrum 
- this is an implementation of agile methodology
- Iterative approach: it cycles through all the aforementioned steps every 2-4 weeks 
- *Sprint* is the term that denotes the cycle

#### Sprint
- Sprint planning: You look at your long wishlist (Product backlog) and determine what you think can be accomplished during this particular sprint.
    - We take the item from product backlog and then turn that into user stories
    - We assign items we want to accomplish in this sprint a numeric value that denotes how much resource(time, etc) it's going to take to finish it. (story points)
        - We usually use fibonacci numbers for these (1, 1, 2, 3, 5, etc.)
    - The items that's been selected for sprint goes to sprint backlog 
- When you are in the sprint
    - Daily Scrum meeting with your team (standup) every morning
        - This is a short 5-10 min max meeting where the team gets an opportunity to catch each other up
        - Each team member answers 3 questions:
            - What did you do yesterday?
            - What are you going to do today?
            - Any Blockers? 
        - Blockers are any issues that you're facing that is preventing you from progressing
    - Burndown chart
        - which is a graph that shows how on track the team is from finishing the sprint
    - Sprint velocity
        - How fast are we going through these items
    - Kanban board
        - The board that the team uses to track each items progress
        - Product backlog, sprint backlog, doing, testing, qc, ready for deploy, done
        - Product backlog: all your wishes (the big wishlist)
        - sprint backlog: all the things you want to do for this sprint
        - Doing: Someone's working on it
        - Testing/QC: It's been done, now we're testing/verifying
        - Ready for deploy/done: It's ready to be released
        - Teams use tools like Trello, Jira, Monday, etc.
- When you're done with the sprint
    - Sprint retrospective (we talk about how the whole process went)
        - What went well? What did we do well?
        - What could have been better?
        - What we could do differently next time?

- And then, you repeat this all over again and fix any bugs/issues that came from previous sprints