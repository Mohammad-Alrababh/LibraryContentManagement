<h1 align="center"> Content Management System Library</h1>

This project is a content management system (CMS) library developed in C# that serves as the core for building robust CMS applications. It is designed to manage posts, authors, and readers while providing functionalities for tagging, following, and content retrieval.


## Prerequisites

Ensure you have the following installed:
  + [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
  + [Git](https://git-scm.com/)
  + [XUnit](https://xunit.net/) (for running unit tests)

  
## Quick Start

 ### Cloning the Repository
  + Using a terminal navigate into the directory where you want the repository to be cloned.
```sh
cd /Path/To/The/Directory
```
  + Clone the repository using git:
```sh
git clone https://github.com/Mohammad-Alrababh/LibraryContentManagement.git
```
### Running the project and tests
#### While in the same directory
  ##### Run the project
```sh
dotnet run --project Library
```
  ##### Run the tests
```sh
dotnet test LibraryTests
```
### Local Compilation and Execution

To compile and run the source code locally, follow these steps:
1. Clone the repository to your local machine.
2. Open the solution in your preferred C# IDE (e.g., Visual Studio).
3. Build the solution and execute the application.
4. Run the tests

## Project Overview

This library includes:
1. Core types and logic for content management.
2. A sample application demonstrating the library’s functionalities.
3. Unit tests for validating the library's functionalities.
4. Instructions for compiling and running the source code.

## Library Features

### Core Components
- **Posts**: The primary content type of the system. Posts can be blog entries, articles, surveys, etc., each having content text, creation and publish dates, and a status indicator (draft, published, etc.).
  
- **Authors**: System users who create content within the system. Authors can:
  - Create and update draft posts, visible only to them until published.
  - Publish draft posts to make them available to all readers.
  - Delete draft posts (published posts cannot be deleted).
  - Edit tags on draft posts to describe main topics (e.g., “Azure”, “CloudTechnology”).

- **Readers**: System users who consume the created content. Readers can:
  - Follow specific tags to see relevant posts.
  - Follow specific authors to see new posts by those authors.
  - Get and read specific posts.
  - Search for posts with specific tags.

- **Content Engine**: The central component of the system, ensuring the validity of content management operations. It manages:
  - Creating, updating, publishing, deleting, and retrieving posts.
  - Associating readers with tags or authors they follow.
  - Listing posts based on filters (e.g., by author, tag, or user following).

- **Data Context**: Mimics the functionalities of a database and the performance of CRUD operations on the data source.

- **User Engine**: Handles the registration, updating, and removal of authors or readers.

## Sample Application

The accompanying application demonstrates the library’s capabilities. It includes the following features:
- Creation of multiple authors and readers.
- Creation of sample posts (draft and published) for each author.
- Assignment of tags to each post.
- Functionality for users to follow tags and authors.
- Listing of posts that a specific user is following.



