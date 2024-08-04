# Service Watchdog

## About

This project is a Windows service management tool developed using WinForms. It allows users to add and control Windows services with functionalities such as starting, stopping, restarting, automatic restarting, and sequential starting. Additionally, it sends SMS notifications on service status changes and displays real-time CPU, RAM, disk, and network information.

## Screenshot
![Interface](Screenshots/Watchdog.png)

## Features

- **Service Management**: Add, start, stop, restart, and manage Windows services.
- **Automatic Restart**: Automatically restart services when they stop unexpectedly.
- **Sequential Starting**: Start services in a specified order.
- **SMS Notifications**: Send SMS notifications on service status changes.
- **Real-Time Monitoring**: Display real-time information on CPU, RAM, disk, and network usage.

## Technologies Used

- **C# WinForms**: Framework for building the desktop application interface.
- **.NET Framework/Core**: Backend logic and operations.
- **Third-Party Libraries**: Utilizes libraries for SMS notifications and system monitoring.
- **Visual Studio**: Integrated development environment used for development.

## Installation

1. **Clone the Repository**:
    ```sh
    git clone https://github.com/BeratARPA/Service-Watchdog.git
    ```
2. **Open with Visual Studio**: Open the project in Visual Studio.
3. **Install Dependencies**: Restore any necessary dependencies.
4. **Build the Project**: Build the solution to ensure proper setup.
5. **Run the Project**: Press F5 to run the project and access the service management interface.

## Usage

1. **Launch the Application**: Start the application from Visual Studio or the executable.
2. **Add Services**: Add the Windows services you want to manage.
3. **Control Services**: Use the interface to start, stop, restart, or set up automatic restart for services.
4. **Set Notifications**: Configure SMS notifications for service status changes.
5. **Monitor System**: View real-time CPU, RAM, disk, and network usage.

## Contributing

If you would like to contribute, please fork the repository, create a feature branch, and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contact

For questions or feedback, feel free to contact me:
- **Email**: [beratarpa@hotmail.com](mailto:beratarpa@hotmail.com)
- **GitHub**: [https://github.com/BeratARPA](https://github.com/BeratARPA)
