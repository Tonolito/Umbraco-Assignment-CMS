# Umbraco Assignment CMS

An Umbraco CMS school project built with .NET 9 and Umbraco 16.

The site includes:
- Home, About, Services, Service Detail, and Contact pages
- Block List / Block Grid based content sections
- Custom forms for callback requests, questions, and email signups
- Email confirmation via Azure Communication Services
- uSync for syncing content types, templates, media, and seeded content
- A custom backoffice rich text editor style package in `App_Plugins/Onatrix_Rte`

## Tech Stack

- .NET 9
- Umbraco CMS 16.2.0
- uSync 16.1.0
- Azure Communication Email
- SQLite for local development
- Azure SQL configured for non-development environments

## Project Structure

```text
App_Plugins/           Custom Umbraco backoffice extensions
Controllers/           Surface controllers
Models/                Request models
Services/              Form persistence and email services
ViewModels/            Form view models and validation
Views/                 Umbraco templates and partials
wwwroot/               Static assets
uSync/v16/             Synced Umbraco schema, content, templates, and media
Program.cs             App startup and service registration
```
