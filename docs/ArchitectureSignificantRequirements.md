# Architecture Significant Requirements

## Utility Tree

| Quality Attribute      | Refinement          | Quality Attribute Scenario                                                              | Business Value | Technical Risk |
|------------------------|---------------------|-----------------------------------------------------------------------------------------|----------------|----------------|
| Benutzerfreundlichkeit | Intuitive Bedienung | Benutzer kann ohne Schulung problemlos Reservierungen vornehmen.                        | H              | M              |
| Benutzerfreundlichkeit | Barrierefreiheit    | Benutzer mit Behinderungen können das System nutzen (z. B. Screenreader-Unterstützung). | M              | H              |
| Funktionalität         | Fehlerfreiheit      | Das System ermöglicht fehlerfreie Reservierungen, selbst bei ungültigen Eingaben.       | H              | M              |
| Funktionalität         | Datenkonsistenz     | Alle Reservierungen sind konsistent und sichtbar auf allen Geräten.                     | H              | L              |
| Sicherheit             | Zugriffskontrolle   | Nur autorisierte Benutzer können Reservierungen ändern oder stornieren.                 | H              | M              |

## Architekturentscheidungen und Entwurfsmuster

### Architekturentscheidungen

- **Architekturtyp: Monolithische Architektur**
  - Da das Projekt klein und überschaubar ist, wird eine monolithische Architektur verwendet. Alles ist in einer Anwendung integriert, ohne die Notwendigkeit für komplexe Verteilungen oder Microservices.
  - **Bezug zu Quality Attributes:** Diese Entscheidung trägt zur **Benutzerfreundlichkeit** bei, da alles in einem System zu finden ist, ohne dass Benutzer zwischen verschiedenen Teilen der Anwendung wechseln müssen.

- **Datenbank: SQLite**
  - Für die Speicherung der Reservierungen und Benutzerdaten wird SQLite verwendet. Dadurch erleichtern wir uns den Entwicklungsaufwand.
  - **Bezug zu Quality Attributes:** Sie unterstützt **Datenkonsistenz** und **Fehlerfreiheit**, da die Reservierungsdaten jederzeit konsistent und sicher gespeichert werden.

- **Benutzertypen und Zugriffskontrollen**
  - Es werden verschiedene Benutzertypen **User**, **Local Admin** und **Global Admin** definiert, um unterschiedliche Zugriffsmöglichkeiten auf das System zu gewährleisten.
  - **Bezug zu Quality Attributes:** Diese Entscheidung sorgt für **Sicherheit**, da nur autorisierte Benutzer bestimmte Funktionen durchführen können.

---
### Entwurfsmuster

- **Entwurfsmuster: Model-View-Controller (MVC)**
  - Das **MVC**-Muster wird eingesetzt, um die Benutzeroberfläche (View) von der Geschäftslogik (Model) zu trennen. Das sorgt für eine klare Struktur und erleichtert spätere Erweiterungen.
  - **Bezug zu Quality Attributes:** Dies trägt zur **Benutzerfreundlichkeit** bei, da die Benutzeroberfläche unabhängig von der zugrunde liegenden Logik gestaltet und angepasst werden kann.

- **Entwurfsmuster: Singleton Pattern (für Datenbankverbindung)**
  - Das **Singleton Pattern** wird verwendet, um sicherzustellen, dass nur eine Instanz der Datenbankverbindung im gesamten System existiert. Dies vermeidet unnötige Verbindungen und stellt sicher, dass alle Teile der Anwendung mit derselben Datenbank arbeiten.
  - **Bezug zu Quality Attributes:** Diese Entscheidung unterstützt **Fehlerfreiheit** und **Datenkonsistenz**, indem die Datenbankverbindung zentral und konsistent genutzt wird.

---
### Taktiken, die das Projekt anwendet

- **Taktik zur Benutzerfreundlichkeit:**
  - **Einfache Benutzeroberfläche:** Wir gestalten die Anwendung so, dass sie auch ohne Anleitung leicht verständlich und nutzbar ist.
  - **Bezug zu Quality Attributes:** Fördert die **Benutzerfreundlichkeit**, da die Benutzer ohne Schwierigkeiten Reservierungen vornehmen können.

- **Taktik zur Funktionalität:**
  - **Eingabevalidierung:** Alle Benutzereingaben (z. B. bei der Reservierung) werden überprüft, um sicherzustellen, dass keine ungültigen oder fehlerhaften Daten in die Datenbank gelangen.
  - **Bezug zu Quality Attributes:** Diese Taktik stellt sicher, dass das System **fehlerfrei** arbeitet und keine inkonsistenten Daten speichert.

- **Taktik zur Sicherheit:**
  - **Passwort-Hashing:** Passwörter werden vor der Speicherung gehasht, um die Sicherheit der Benutzerdaten zu gewährleisten.
  - **Bezug zu Quality Attributes:** Dies stellt sicher, dass die **Sicherheit** des Systems gewahrt bleibt und Benutzerdaten nicht im Klartext gespeichert werden.
