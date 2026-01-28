# Flash Study

Flash Study is a cross platform flashcard app built with .NET MAUI. It lets you create decks and cards, then study them in a simple review flow.

## Features
- Create, edit, and delete decks
- Add, edit, and delete cards within a deck
- Study mode with flip, next, and previous controls
- Local SQLite storage
- Seeded starter decks for quick testing

## Tech stack
- .NET MAUI
- CommunityToolkit.Mvvm
- sqlite-net-pcl

## Getting started
1) Open the solution in Visual Studio 2022 or newer
2) Restore NuGet packages
3) Select a target platform and run

## Running from the command line
```bash
dotnet restore
dotnet build
```

## Data storage
The app stores data in a SQLite database at the platform app data path. The database file name is `flashcards.db3`.

## Seed data
On first launch, the app inserts a few sample decks if they do not already exist:
- System Design
- Software Engineer
- CSharp

Seed logic lives in `FlashStudy/Data/SeedData.cs` and is called from `FlashStudy/Data/AppDatabase.cs`.

## Project structure
- `FlashStudy/Views` UI pages
- `FlashStudy/ViewModels` MVVM view models
- `FlashStudy/Models` data models
- `FlashStudy/Data` SQLite access and repositories
- `FlashStudy/Resources` images, fonts, styles

## Notes
- If you change seed data after a deck already exists, new cards will not be inserted unless you update the seed logic.
