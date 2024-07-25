# Aufgabenstellung


## Projekt Beteiligte

| Username        | Matr. Nr.    |
|-----------------|--------------|
| LimitlessGreen  | Siehe Mail   |
| TRIIRT          | Siehe Mail   |

## Problemstellung

- **Xeno-Canto** (Online-Plattform der Xeno-canto Foundation + Naturalis Biodiversity Centers) 
  - Ermöglicht Teilen und Anhören von Tierstimmen verschiedenster Arten
  - Ziel der Plattform: Sammlung von Tierstimmen zu erstellen (Unterstützt Vögel, Fledermäuse, Frösche und Grashüpfer)
  - Schwächen der Plattform: Daten nur mit "weak labels" versehen
    - Daten sind gelabelt, ohne die genauen Zeit- und Frequenzabschnitte, in denen die Tiere zu hören sind, zu kennen

## Zielsetzung

- Projektziel: Verbesserung der Datenbasis von Xeno-Canto
- Schaffung der öffentlichen Möglichkeit zur Labelung der von Xeno-Canto bewerteten Aufnahmen (Wikipedia-Prinzip)
- Darstellung der Labels in Zeit-Frequenz-Plot (Spektrogramm) -> genaue Lokalisierung der Tierlaute
- Gelabelte Daten über API zugänglich -> Nutzung der Daten ermöglicht (z. B. für Forscher und Entwickler)
- Idealfall: Daten an Xeno-Canto zurückgeben

## Umzusetzende Funktionalitäten

### Pflicht

#### Backend

- Xeno-Canto API Anbindung
- Speichern von gelabelten Daten in einer Datenbank
- API zur Abfrage der gelabelten Daten
- Generierung von Spektrogrammen

#### Frontend

- Anzeige der Aufnahmen (Spektrogramm)
- Labeling der Aufnahmen
- Anzeige der gelabelten Daten

### Optional (für die Zukunft)

- History der gelabelten Daten
- Automatisches Preprocessing der Aufnahmen zum besseren Labeln (z. B. Rauschunterdrückung, Normalisierung)
- Integration von Machine Learning Modellen zur automatischen Labelgenerierung (z. B. BirdNet Analyzer)
- Mehrbenutzerfähigkeit
  - User-Management
  - Rechteverwaltung
  - Kommentarfunktion
  - Authentifizierung

## Technologien (Vorauswahl) (Unvollständig)

| Funktion             | Technologie                |
|----------------------|----------------------------|
| Backend              | .NET Core                  |
| Datenbank            | PostgreSQL                 |
| Datenbankmanagement  | Entity Framework Core      |
| API Dokumentation    | Swagger                    |
| API Bereitstellung   | ASP.NET Core Web API       |

## Grobe Aufgabenverteilung

| Aufgabe  | Verantwortlicher  |
|----------|-------------------|
| Backend  | LimitlessGreen    |
| Frontend | TRIIRT            |
