Project Name: Service Monitoring and Management Application
Scenario:

A company has a Windows Service and an IIS Service in its infrastructure. These services perform specific tasks, but occasionally encounter errors or stoppage situations. The company plans to develop a monitoring and management application to ensure the continuous operation of these services and to automatically restart them in case of any stoppage.
Application Functionality:

Monitoring Service:

    Positioned as a Windows service.
    Checks the status of the relevant services at specified intervals.
    Restarts the services in case of stoppage.
    Logging of service operations is important for external monitoring.

Settings Application:

    Designed as a WinForms application.
    Manages service information, monitoring frequency, and log level.

Mock Services:

    Windows Service: Monitors a file directory and logs any changes. Writes logs when started and stopped.
    Web API (IIS): Implements two methods:
        int Sum(int x, int y)
        string Ping()
        Supports Swagger for testing via Swagger UI.
        Writes logs when the service is running and for incoming requests.

Unit Test Project:

Unit tests are written for the business methods used in the Monitoring Service and Settings Application projects.

By developing an application in this manner, the company will be able to monitor, manage, and take preventive measures against possible errors in its Windows and IIS services.
