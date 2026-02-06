# Flash Study

Flash Study is a cross-platform flashcard application built with .NET MAUI.  
It supports deck and card management, focused study sessions, and local-first persistence using SQLite.

## Product Highlights
- Cross-platform single-project MAUI app targeting Android, iOS, Mac Catalyst, and Windows.
- MVVM architecture using `CommunityToolkit.Mvvm` with command-based navigation and page lifecycle loading.
- Local SQLite storage with repository abstraction for decks and cards.
- Professional seed content with four interview and engineering focused starter decks.
- Theme-aware study card styling for readable question and answer text across light and dark modes.

## Feature Set

### Deck Management
- Create new decks from the main page.
- View deck card counts directly in the deck list.
- Open and delete decks with confirmation prompts.
- Deck list refreshes automatically when returning to the page.

### Card Management
- Add cards to any deck.
- Edit existing cards.
- Delete cards with confirmation prompts.
- Search cards by question (`Front`) or answer (`Back`) with case-insensitive filtering.

### Study Mode
- Flip between question and answer.
- Navigate previous and next cards.
- Cards are randomized per study session (`Fisher-Yates` shuffle in `StudyViewModel`).
- Handles empty decks with a user-visible fallback message.

### Seeded Starter Decks
The app seeds these decks on first initialization:
- `System Design`
- `Software Engineer`
- `CSharp`
- `Golang`

Seed answers are written in complete 2-3 sentence format and include abbreviation expansion where applicable.

## Architecture
- `Views`: MAUI XAML pages and code-behind lifecycle hooks (`OnAppearing` loads).
- `ViewModels`: state and commands for deck list, deck detail, card edit, and study flow.
- `Models`: `Deck` and `Card` SQLite entities.
- `Data`: database bootstrap, seed data, and repositories.
- `Resources`: app icon, splash, logo, fonts, and shared styles.

The app uses dependency injection in `MauiProgram` for:
- `AppDatabase`
- `DeckRepository`
- `CardRepository`
- Page and ViewModel registrations

## Technology Stack
- `.NET MAUI` (`net10.0-*` target frameworks)
- `CommunityToolkit.Mvvm`
- `sqlite-net-pcl`
- `SQLitePCLRaw.bundle_green`

## Getting Started

### Prerequisites
- Visual Studio 2022 (or newer) with MAUI workloads
- .NET SDK compatible with project target frameworks (`net10.0-*`)
- Android/iOS platform tooling depending on target device

### Run in Visual Studio
1. Open `Flash-Study.sln`.
2. Restore NuGet packages.
3. Select target platform and run.

### Run from CLI
```bash
dotnet restore
dotnet build Flash-Study.sln
```

## Publish

### Android Release APK
```bash
dotnet publish FlashStudy/FlashStudy.csproj -c Release -f net10.0-android
```

Publish output:
- `FlashStudy/bin/Release/net10.0-android/publish/`

## Data Storage
- SQLite database file: `flashcards.db3`
- Location: `FileSystem.AppDataDirectory` (platform-specific app data path)
- Initialization and seeding entry point: `FlashStudy/Data/AppDatabase.cs`

## Seed Data Lifecycle
- Seed methods run during database initialization.
- Each deck is inserted only if it does not already exist.
- Updating `SeedData.cs` does not update existing seeded decks automatically.

If you need seed content updates to apply to existing installs, implement a migration or clear local app data.

## Navigation Routes
Registered in `FlashStudy/AppShell.xaml.cs`:
- `DeckDetailPage`
- `EditCardPage`
- `StudyPage`

## Project Structure
- `FlashStudy/Views`
- `FlashStudy/ViewModels`
- `FlashStudy/Models`
- `FlashStudy/Data`
- `FlashStudy/Data/Repositories`
- `FlashStudy/Resources`

## Current Version Metadata
Configured in `FlashStudy/FlashStudy.csproj`:
- `ApplicationTitle`: `FlashStudy`
- `ApplicationDisplayVersion`: `1.0`
- `ApplicationVersion`: `1`
