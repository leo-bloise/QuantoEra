# Quanto Era Solution

A comprehensive suite of .NET projects designed for financial calculations and utility functions.

## 🚀 Getting Started

To explore and run "Quanto Era" locally , please follow these steps:

### Prerequisites

Ensure you have the following installed on your development machine:

*   [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (or newer)
*   A preferred code editor such as [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/), or [JetBrains Rider](https://www.jetbrains.com/rider/)

### Build

Navigate to the root directory of this repository (`/home/leonardo/Projects/QuantoEra/`) in your terminal and build:

```bash
dotnet build
```

This command will automatically restore all necessary NuGet packages for each project and compile them.

### Running the QuantoEra.Web Application

The primary way to interact with the app is through the `QuantoEra.Web` Blazor application:

1.  From the repository root, change your directory to the `QuantoEra.Web` project:
    ```bash
    cd QuantoEra.Web
    ```
2.  Run the application using the .NET CLI:
    ```bash
    dotnet run
    ```
3.  The application will typically launch and become accessible in your web browser at `http://localhost:5289` (the exact port may vary and will be displayed in your terminal output).
4.  Open your web browser and visit the displayed URL to start using the "Quanto Era" web application.

### Running with Docker

You can also build and run the `QuantoEra.Web` application using Docker. A convenience script `build_and_run_docker.sh` is provided for this purpose.

1.  Ensure you have Docker installed and running on your system.
2.  Make the script executable:
    ```bash
    chmod +x build_and_run_docker.sh
    ```
3.  Execute the script from the root of the repository:
    ```bash
    ./build_and_run_docker.sh
    ```
    This script will:
    *   Build the Docker image named `quantoera-web`.
    *   Run a new Docker container named `quantoera-app`, mapping port `8080` from the container to your host machine.
4.  Once the script completes, the application will be accessible at `http://localhost:8080` in your web browser.

## 📁 Projects Overview

Quanto Era is structured into the following distinct projects:

### 1. QuantoEra.Web

*   **Description:** This is a Blazor Server-side web application, serving as the interactive user interface for the "Quanto Era". It demonstrates and utilizes the functionalities provided by its sibling projects, notably the IPCA correction calculation.
*   **Key Features:**
    *   **IPCA Correction Calculation:** Offers an intuitive web interface for calculating the IPCA (Índice Nacional de Preços ao Consumidor Amplo - Brazil's official inflation index) correction for a specific monetary value and date.
    *   **User-Friendly & Responsive Design:** Crafted with a clean, modern, and mobile-first approach, ensuring optimal usability across all device types.
*   **Technologies Used:** .NET 9.0, Blazor, C#, Bootstrap.

### 2. QuantoEra.IPCA

*   **Description:** A dedicated .NET library project designed to centralize the core logic and data handling for IPCA (inflation index) calculations. This library is built for reusability, allowing any .NET application requiring accurate inflation adjustments to integrate its robust functionalities.
*   **Purpose:** To provide a reliable, maintainable, and standalone component for all IPCA-related financial computations within the "Quanto Era" ecosystem and beyond.

### 3. QuantoEra.Calendar

*   **Description:** This .NET library project is envisioned to contain essential utilities and business logic pertaining to calendar operations. This could include advanced date manipulations, handling specific financial calendar rules, or managing holiday schedules.
*   **Purpose:** To offer a versatile and reusable module for managing complex date and calendar-based requirements, ensuring consistency across the solution. 