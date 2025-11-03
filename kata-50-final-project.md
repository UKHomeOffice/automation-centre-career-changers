# Final Project

## Overview

This final project is designed to consolidate and apply the knowledge and skills you have acquired throughout the previous katas. You will build a complete web application using C#, .NET, HTML, CSS, TypeScript, and React.

## Pair Programming

When you start this project, it is recommended that you have regular sessions with your mentor, working together on the project. This will help you to get feedback on your code, discuss design decisions, and learn best practices.

There will be times that you're both on the same computer working together, and other times when you will work separately.

If you get stuck, your mentor is there to help you. Don't be afraid to ask questions or seek guidance!

## Objectives

- Design and implement a full-stack web application.
- Utilize C# and .NET for the backend development.
- Use HTML, CSS, and React for the frontend development.
- Use SQL Server for data storage and retrieval.
- Implement unit testing to ensure code quality and reliability.

## Project Requirements

1. Data Entities

   - Visa Application
     - Properties
       - Id (int)
       - ApplicantName (string)
       - DateOfBirth (DateTime)
       - PassportNumber (string)
       - Nationality (FK to Country)
       - ApplicationDate (DateTime)
       - Status (FK to ApplicationStatus)
       - VisaType (FK to VisaType)
     - Relationships
       - Each Visa Application is associated with one Country, one Application Status, and one Visa Type.
   - Country
     - Options:
       - GB - Great Britain
       - US - United States
       - CA - Canada
       - AU - Australia
       - IN - India
       - CN - China
       - FR - France
       - DE - Germany
       - JP - Japan
   - ApplicationStatus
     - Options: New, Review, Approved, Rejected
   - VisaType
     - Options: Tourist, Work, Student

2. API Endpoints

   - `GET /api/visa-applications`
     - Retrieve a list of all visa applications.
     - With ability to filter by status or visa type via query string parameters.
   - `GET /api/visa-applications/{id}`
     - Retrieve details of a specific visa application by its ID.
   - `POST /api/visa-applications`

     - Create a new visa application.
     - Request Body Example:

       ```json
       {
         "applicantName": "John Doe",
         "dateOfBirth": "1990-01-01T00:00:00",
         "passportNumber": "A12345678",
         "nationality": "GB",
         "visaType": "Tourist"
       }
       ```

   - `PUT /api/visa-applications/{id}/status`

     - Update the status of an existing visa application.

       - Options: New, In Review, Approved, Rejected
       - Request Body Example:

       ```json
       {
         "status": "In Review"
       }
       ```

   - `DELETE /api/visa-applications/{id}`
     - Delete a visa application.

3. Frontend Features

   - Display a list of visa applications with filtering options.
   - View detailed information about a specific visa application.
   - Form to submit a new visa application.
   - Option to update the status of an application.

4. Unit Testing
   - Implement unit tests for backend API endpoints.
   - Ensure at least 80% code coverage.
   - Use NUnit as a testing framework for the API and React Testing Library with Jest for the frontend.

## Submission Guidelines

- Host your project in GitHub
- Commit your code regularly with meaningful commit messages.
- Include a README.md file with instructions on how to set up and run your application.
- You should have a Bruno collection for API testing created.
