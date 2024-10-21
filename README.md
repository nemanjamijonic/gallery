# RVA - Razvoj viseslojnih aplikacija

## Project Description

This project is a WPF application developed using the **MVVM (Model-View-ViewModel)** pattern, designed to manage art pieces, authors, and galleries. It communicates with the backend using **WCF (Windows Communication Foundation)** and interacts with a **SQL database** through **Entity Framework**.

### Key Features:

- **User Registration and Login**: Users can register and log in to the system.
- **Admin Privileges**: Admins have the ability to add, edit, and delete records for artworks, authors, and galleries.
- **Regular Users**: Regular users can view the records but do not have the ability to modify them.
- **Data Management**: CRUD operations (Create, Read, Update, Delete) are implemented for:
  - **Art Pieces** (`UmetnickoDelo`)
  - **Authors** (`Autor`)
  - **Galleries** (`Galerija`)

The project emphasizes the implementation of design patterns, ensuring clean architecture and maintainability. Its purpose is to demonstrate the use of patterns in a real-world application while facilitating efficient data management and user interactions.

## Design Patterns

Implemented design patters are displayed in NClass project in this repository [RvaProjectGallery.ncp].
**NOTE**: The images shown as examples are not the only parts of the code where these patterns are applied; rather, they are simply examples provided to simplify the explanation of how the pattern is used in the task.

### Singleton

The **Singleton** pattern is implemented to ensure that only one instance of the `MyDbContext` class is created and reused throughout the application. This is crucial for efficient database management, preventing the overhead of creating multiple instances and avoiding potential conflicts.

The `MyDbContextFactory` class is responsible for providing the `MyDbContext` instance and implements the `IDbContextFactory<MyDbContext>` interface, which defines the `Create()` method. This method ensures that the instance is created only once, using lazy initialization, and is reused across the application whenever a database context is required.

By using this pattern, the application optimizes resource usage and ensures compatibility with Entity Framework, maintaining a single database context throughout its operation.

![alt text](<singleton rva.png>)

### Observer

The **Observer** pattern is implemented to manage the relationship between objects such that when one object changes state, all dependent objects are notified and updated automatically. This pattern ensures that any changes in the subject (observable) are reflected in the observers.

In this project, the `UserActionLoggerService` plays the role of the subject in the Observer pattern. It maintains a collection of log messages and notifies subscribed observers when a new message is added.

Key components include:

- **ILogInterface**: Defines the `Log` method for logging user actions.
- **UserActionLoggerService**: Implements the `ILogInterface` and is responsible for storing and managing log messages. It fires the `LogMessageAdded` event when a new log message is added, notifying all observers.
- **BaseViewModel**: Implements `INotifyPropertyChanged` to support data binding and notify the UI when property values change.
- **UserActionViewModel**: Acts as the observer, subscribing to the `LogMessageAdded` event in its constructor. It receives notifications whenever a new log is added to the `UserActionLoggerService` and updates its `UserActions` collection accordingly.

By using this pattern, the system ensures that any changes made to the log messages are immediately reflected in the view models, enabling real-time updates to the UI without the need for manual refreshes or polling.

![alt text](<observer rva.png>)

### Command

The **Command** pattern is a design pattern that encapsulates a request as an object, allowing for parameterization of methods with different requests, queuing of requests, and providing support for undoable operations.

This implementation defines an abstract `Command` class that provides methods for `Execute` and `UnExecute`. This abstraction allows for a flexible and extensible hierarchy of commands.

The concrete command classes (`AddGalleryCommand`, `DeleteGalleryCommand`, `DuplicateGalleryCommand`, `EditGalleryCommand`) encapsulate specific operations related to the `Gallery` object. Each command properly implements the `Execute` and `UnExecute` methods, enabling the execution and reversal of specific actions.

The `CommandManager` class maintains two stacks, `_undoStack` and `_redoStack`, to handle undo and redo operations. This class provides methods to execute commands, as well as undo and redo, ensuring efficient management of state changes. By using stacks to manage operations, every executed command is added to the `_undoStack`, while clearing the `_redoStack` ensures that redo operations are reset whenever a new command is executed.

Each concrete command uses services (`IGalleryService`) and models (`Gallery`) that encapsulate the business logic and data. This separation of concerns keeps the commands focused on their specific tasks and promotes code reuse.

Key components include:

- **Command**: Abstract class defining `Execute` and `UnExecute` methods.
- **CommandManager**: Manages command execution and provides undo and redo functionality through the use of stacks.
- **GalleryCommand**: Base class for gallery-related commands, handling the `Gallery` model.
- **AddGalleryCommand**, **DuplicateGalleryCommand**, **EditGalleryCommand**, **DeleteGalleryCommand**: Concrete command classes implementing specific operations (adding, duplicating, editing, and deleting galleries).

This pattern implementation supports a structured approach to command handling, allowing for flexible, maintainable, and undoable operations within the system.

![alt text](<command rva.png>)
