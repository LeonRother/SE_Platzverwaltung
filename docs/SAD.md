@

**<Project Name>**

**Software Architecture Document**

**Version <1.0>**

*[Note: The following template is provided for use with the Rational Unified Process. Text enclosed in square brackets and displayed in blue italics (style=InfoBlue) is included to provide guidance to the author and should be deleted before publishing the document. A paragraph entered following this style will automatically be set to normal (style=Body Text).]*

*[To customize automatic fields in Microsoft Word (which display a gray background when selected), select File>Properties and replace the Title, Subject and Company fields with the appropriate information for this document. After closing the dialog, automatic fields may be updated throughout the document by selecting Edit>Select All (or Ctrl-A) and pressing F9, or simply click on the field and press F9.  This must be done separately for Headers and Footers.  Alt-F9 will toggle between displaying the field names and the field contents.  See Word help for more information on working with fields.]* 

**Revision History**

| **Date**    | **Version** | **Description** | **Author** |
| ----------- | ----------- | --------------- | ---------- |
| <dd/mmm/yy> | <x.x>       | <details>       | <name>     |
| <br>        | <br>        | <br>            | <br>       |
| <br>        | <br>        | <br>            | <br>       |
| <br>        | <br>        | <br>            | <br>       |

1. Introduction     

        1.1Purpose

        1.2 Scope     

        1.3 Definitions, Acronyms, and Abbreviations

        1.4 References

        1.5 Overview

2. Architectural Representation     

3. Architectural Goals and Constraints     

4. Use-Case View
   
   4.1Use-Case Realizations

5. Logical View    
   
   5.1 Overview
   
   5.2 Architecturally Significant Design Packages

6. Process View

7. Deployment View

8. Implementation View 
   
   8.1Overview     
   
   8.2 Layers

9. Data View (optional)     

10. Size and Performance     

11. Quality    

# **Software Architecture Document**

## **1.Introduction**

*[The introduction of the* ***Software Architecture Document*** *provides an overview of the entire* ***Software Architecture Document****. It includes the purpose, scope, definitions, acronyms, abbreviations, references, and overview of the* ***Software Architecture Document****.]*

### **1.1.Purpose**

This document provides a comprehensive architectural overview of the system, using a number of different architectural views to depict different aspects of the system. It is intended to capture and convey the significant architectural decisions which have been made on the system.

*[This section defines the role or purpose of the* ***Software Architecture Document****, in the overall project documentation, and briefly describes the structure of the document. The specific audiences for the document is identified, with an indication of how they are expected to use the document.]*

### **1.2.Scope**

*[A brief description of what the Software Architecture Document applies to; what is affected or influenced by this document.]*

### **1.3.Definitions, Acronyms, and Abbreviations**

*[This subsection provides the definitions of all terms, acronyms, and abbreviations required to properly interpret the* ***Software Architecture Document****.  This information may be provided by reference to the project’s Glossary.]*

### **1.4.References**

*[This subsection provides a complete list of all documents referenced elsewhere in the* ***Software Architecture Document****. Identify each document by title, report number (if applicable), date, and publishing organization. Specify the sources from which the references can be obtained. This information may be provided by reference to an appendix or to another document.]*

### **1.5.Overview**

*[This subsection describes what the rest of the* ***Software Architecture Document*** *contains and explains how the* ***Software Architecture Document*** *is organized.]*

## **2.Architectural Representation**

*[This section describes what software architecture is for the current system, and how it is represented. Of the* ***Use-Case****,* ***Logical****,* ***Process****,* ***Deployment****, and* ***Implementation Views****, it enumerates the views that are necessary, and for each view, explains what types of model elements it contains.]*

## **3.Architectural Goals and Constraints**

*[This section describes the software requirements and objectives that have some significant impact on the architecture; for example, safety, security, privacy, use of an off-the-shelf product, portability, distribution, and reuse. It also captures the special constraints that may apply: design and implementation strategy, development tools, team structure, schedule, legacy code, and so on.]*

## **4.Use-Case View**

*[This section lists use cases or scenarios from the use-case model if they represent some significant, central functionality of the final system, or if they have a large architectural coverage—they exercise many architectural elements or if they stress or illustrate a specific, delicate point of the architecture.]*

### **4.1.Use-Case Realizations**

*[This section illustrates how the software actually works by giving a few selected use-case (or scenario) realizations, and explains how the various design model elements contribute to their functionality.]*

## **5.Logical View**

*[This section describes the architecturally significant parts of the design model, such as its decomposition into subsystems and packages. And for each significant package, its decomposition into classes and class utilities. You should introduce architecturally significant classes and describe their responsibilities, as well as a few very important relationships, operations, and attributes.]*

### **5.1.Overview**

*[This subsection describes the overall decomposition of the design model in terms of its package hierarchy and layers.]*

### **5.2.Architecturally Significant Design Packages**

*[For each significant package, include a subsection with its name, its brief description, and a diagram with all significant classes and packages contained within the package.* 

*For each significant class in the package, include its name, brief description, and, optionally, a description of some of its major responsibilities, operations, and attributes.]*

## **6.Process View**

##### Frontend

![docs/Frontend.png](https://github.com/LeonRother/SE_Platzverwaltung/blob/7aa0f07f6f5f9078cc6527c5d350d559ea36ee76/docs/Frontend.png)

• **Components:** Enthält wiederverwendbare Vue.js-Komponenten für die Benutzeroberfläche.

• **Views:** Definiert die verschiedenen Ansichten und Seiten der Anwendung.

• **Store:** Verwaltet den globalen Zustand der Anwendung.

• **Assets:** Beinhaltet statische Ressourcen wie Bilder und Stylesheets.

##### Backend

![docs/Backend.png](https://github.com/LeonRother/SE_Platzverwaltung/blob/af139d10ca55ab8ef2bdc1313995473a1a020285/docs/Backend.png)

• **Controllers:** Verarbeitet eingehende HTTP-Anfragen und gibt entsprechende Antworten zurück.

• **Models:** Definiert die Datenstrukturen und Geschäftslogik der Anwendung.

• **Services:** Enthält die Geschäftslogik und dient als Vermittler zwischen Controllern und Datenbank.

• **DataAccess:** Verantwortlich für die Kommunikation mit der SQLite-Datenbank.

## **7.Deployment View**

*[This section describes one or more physical network (hardware) configurations on which the software is deployed and run. It is a view of the Deployment Model. At a minimum for each configuration it should indicate the physical nodes (computers, CPUs) that execute the software and their interconnections (bus, LAN, point-to-point, and so on.) Also include a mapping of the processes of the* ***Process View*** *onto the physical nodes.]*

## **8.Implementation View**

##### Platz Buchen

![docs/Platz_Buchen.png](https://github.com/LeonRother/SE_Platzverwaltung/blob/a636f8bd3f18764a11aaf361574c43a3db22966e/docs/Platz_Buchen.png)

##### Plätze verwalten

![docs/Plätze_Verwalten.png](https://github.com/LeonRother/SE_Platzverwaltung/blob/664b9fdab466c7cc1f8381577ce8f228d0958d0f/docs/Pl%C3%A4tze_Verwalten.png)

### **8.1.Overview**

*[This subsection names and defines the various layers and their contents, the rules that govern the inclusion to a given layer, and the boundaries between layers. Include a component diagram that shows the relations between layers. ]*

### **8.2.Layers**

*[For each layer, include a subsection with its name, an enumeration of the subsystems located in the layer, and a component diagram.]*

## **9.Data View (optional)**

*[A description of the persistent data storage perspective of the system. This section is optional if there is little or no persistent data, or the translation between the Design Model and the Data Model is trivial.]*

## **10.Size and Performance**

*[A description of the major dimensioning characteristics of the software that impact the architecture, as well as the target performance constraints.]*

## **11.Quality**

*[A description of how the software architecture contributes to all capabilities (other than functionality) of the system: extensibility, reliability, portability, and so on. If these characteristics have special significance, such as safety, security or privacy implications, they must be clearly delineated.]*
