# Dynamic Background Job Frequencies with Quartz.NET

This repository demonstrates how to set up dynamic frequencies for background jobs using the **Quartz.NET** library. With Quartz.NET, you can create scheduled tasks (jobs) that run at specific intervals or according to cron expressions. In this project, we focus on dynamically changing these frequencies based on your application's requirements.

## Features

1. **Background Jobs**: We've implemented a background job system using Quartz.NET. Jobs can be scheduled to run periodically or at specific times.

2. **Dynamic Frequency**: The key feature of this project is the ability to change job frequencies dynamically. You can adjust the execution intervals without redeploying your application.

3. **CRUD Operations for Triggers**:
   - **Add Trigger**: Add a new trigger for a job.
   - **View Trigger**: Retrieve trigger details from a job.
   - **Remove Trigger**: Delete a trigger associated with a job.
   - **Update Trigger**: Modify the schedule for an existing trigger.

## Getting Started

1. **Prerequisites**:
   - .NET Core 8
   - Quartz.NET

2. **Installation**:
   - Clone this repository.
   - Build and run the project.

3. **Usage**:
   - Configure your job(s) in the `Startup.cs` file.
   - Use the provided CRUD endpoints to manage triggers dynamically.
