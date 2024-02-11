# imgui-filebrowser.NET

![303901889-14dcce94-858c-4a7b-a9be-e2b6625c071a](https://github.com/tommybear/imgui-filebrowser.NET/assets/1712535/7e800f34-0e45-4d4c-87d8-f1b1a10c7626)

![303901916-4224bfd9-5e07-44ea-8e7e-22e263f962c1](https://github.com/tommybear/imgui-filebrowser.NET/assets/1712535/ddfbd971-7539-44f3-98cf-3aa8724d2af3)


`imgui-filebrowser.NET` is a highly customizable, easy-to-use file browser for MonoGame applications, leveraging the power of `MonoGame.ImGuiNet`. It is designed to provide developers with a simple yet powerful tool to add file browsing capabilities to their games or tools, with a focus on ease of integration and flexibility.

## Features

- **Single File Integration**: Easy to integrate, with the entire file browser contained in a single `.cs` file.
- **Customizable Appearance**: Offers customizable colors for files, folders, and various file types, enhancing the visual experience.
- **Flexible Browsing Options**: Supports browsing for files, directories, or both, with options for filtering by file type.
- **User Interaction**: Provides functionality for selecting single or multiple files, creating new directories, and more.
- **Adaptable UI**: Allows setting of initial window size, position, and various UI flags for customization.
- **Type Filtering**: Supports filtering visible files by extension, with support for custom type filters.

## Getting Started

To get started with `imgui-filebrowser.NET`, you'll need to have a MonoGame project with `MonoGame.ImGuiNet` set up. If you haven't set up `MonoGame.ImGuiNet` in your project, go here first [MonoGame.ImGuiNet](https://github.com/Mezo-hx/MonoGame.ImGuiNet).

### Installation

1. **Download** the `imFileBrowser.cs` file from the [imgui-filebrowser.NET repository](https://github.com/tommybear/imgui-filebrowser.NET).
2. **Add** the file to your MonoGame project.
3. **Ensure** you have `MonoGame.ImGuiNet` referenced in your project.

4. However, as a convenience a full solution with a test project is included so you can just build and run.

### Basic Usage

To use the file browser in your game or application, follow these steps:

1. **Instantiate** the file browser in your game class:

    ```csharp
    private imFileBrowser fileBrowser;
    ```

2. **Initialize** the file browser in your game's `Initialize` method or constructor:

    ```csharp
    fileBrowser = new imFileBrowser(ImGuiFileBrowserFlags.None);
    ```

3. **Configure** the file browser as needed (optional):

    ```csharp
    fileBrowser.SetTitle("Browse Files");
    fileBrowser.SetPwd(Environment.CurrentDirectory); // Start in the current directory
    fileBrowser.SetTypeFilters(new List<string> { "*.png", "*.jpg", "*.*" }); // Example filters
    ```

4. **Open** the file browser when needed:

    ```csharp
    fileBrowser.Open();
    ```

5. **Display** the file browser in your game's `Draw` method:

    ```csharp
    fileBrowser.Display();
    ```

6. **Handle** selections:

    ```csharp
    if (fileBrowser.HasSelected())
    {
        Console.WriteLine($"Selected: {string.Join(", ", fileBrowser.GetSelected())}");
        fileBrowser.ClearSelected();
    }
    ```

7. **Handle** cancellations:

    ```csharp
    if (fileBrowser.HasCancelled())
    {
        Console.WriteLine("Cancelled!");
    }
    ```

## Customization

`imgui-filebrowser.NET` offers various customization options to tailor the file browser to your needs:

- **Window Size and Position**: Set the initial size and position of the file browser window.
- **Colors**: Customize colors for different elements and file types.
- **Type Filters**: Define filters to only display files of certain types.
- **Flags**: Use flags to enable or disable features like multi-selection, directory selection, and more.

## Configuration Flags

The `imgui-filebrowser.NET` library allows customization through various flags provided by the `ImGuiFileBrowserFlags` enum. These flags can modify the behavior of the file browser, enabling features like directory selection, multiple file selections, and more. Below is a breakdown of each available flag:

```csharp
[Flags]
public enum ImGuiFileBrowserFlags
{
    None = 0,
    SelectDirectory = 1 << 0, // select directory instead of regular file
    EnterNewFilename = 1 << 1, // allow user to enter new filename when selecting regular file
    NoModal = 1 << 2, // file browsing window is modal by default. specify this to use a popup window
    NoTitleBar = 1 << 3, // hide window title bar
    NoStatusBar = 1 << 4, // hide status bar at the bottom of browsing window
    CloseOnEsc = 1 << 5, // close file browser when pressing 'ESC'
    CreateNewDir = 1 << 6, // allow user to create new directory
    MultipleSelection = 1 << 7, // allow user to select multiple files. this will hide ImGuiFileBrowserFlags_EnterNewFilename
    HideRegularFiles = 1 << 8, // hide regular files when ImGuiFileBrowserFlags_SelectDirectory is enabled
    ConfirmOnEnter = 1 << 9, // confirm selection when pressnig 'ENTER'
}
```

### `None`

Represents the default behavior with no special modifications applied.

### `SelectDirectory`

Enables the selection of directories instead of regular files. This is useful when you want users to specify a folder path rather than select individual files.

### `EnterNewFilename`

Allows users to enter a new filename, enabling the file browser to be used for file save operations. This flag makes it possible to specify the name of a new file directly within the file browser interface.

### `NoModal`

By default, the file browser opens in a modal window. Setting this flag changes the behavior to open the file browser in a non-modal, pop-up window instead.

### `NoTitleBar`

Hides the title bar of the file browser window. This option can be used for a more integrated or minimalistic UI appearance.

### `NoStatusBar`

Removes the status bar at the bottom of the file browser window. This is another option for simplifying the UI or when the status bar information is not needed.

### `CloseOnEsc`

Allows the file browser to close when the `ESC` key is pressed, providing a quick way to exit without making a selection.

### `CreateNewDir`

Enables the ability for users to create new directories from within the file browser. This is particularly useful for save file dialogs or when organizing files and folders is needed.

### `MultipleSelection`

Permits the selection of multiple files or directories, depending on the `SelectDirectory` flag's state. When enabled, users can select more than one item by Ctrl-clicking or Shift-clicking.

### `HideRegularFiles`

When the `SelectDirectory` flag is enabled, this flag hides all regular files, showing only directories. This is useful when the user is expected to select a directory, and files are not relevant to the operation.

### `ConfirmOnEnter`

Enables the selection confirmation with the `Enter` key. This provides a keyboard shortcut for quickly confirming selections without clicking the UI.

These flags can be combined to tailor the file browser's functionality to fit your application's needs precisely. For example, to allow multiple directory selections without showing regular files, you could initialize the file browser like this:

```csharp
fileBrowser = new imFileBrowser(ImGuiFileBrowserFlags.SelectDirectory | ImGuiFileBrowserFlags.MultipleSelection | ImGuiFileBrowserFlags.HideRegularFiles);
```

# `imgui-filebrowser.NET` API Documentation

## Overview

`imgui-filebrowser.NET` is a versatile file browser library for MonoGame applications, built on top of `ImGui.NET`. It provides an easy-to-use interface for file selection, directory navigation, and more, with extensive customization options.

## Classes

### `imFileBrowser`

The main class for creating and managing a file browser instance.

#### Constructors

- `imFileBrowser(ImGuiFileBrowserFlags flags = ImGuiFileBrowserFlags.None)`
  Initializes a new instance of the file browser with optional flags for customization.

#### Methods

- `void Open()`
  Opens the file browser window.

- `void Close()`
  Closes the file browser window.

- `void Display()`
  Renders the file browser and handles user interaction. This method should be called every frame.

- `void SetPwd(string pwd)`
  Sets the current working directory for the file browser.

- `void SetTitle(string title)`
  Sets the title of the file browser window.

- `void SetTypeFilters(List<string> typeFilters)`
  Sets the file type filters for the file browser.

- `void SetCurrentTypeFilterIndex(int index)`
  Selects the current file type filter by index.

- `void SetWindowSize(int width, int height)`
  Sets the initial size of the file browser window.

- `void SetWindowPos(int posX, int posY)`
  Sets the initial position of the file browser window.

- `bool HasSelected()`
  Returns `true` if the user has made a selection.

- `List<string> GetSelected()`
  Returns a list of selected file paths.

- `void ClearSelected()`
  Clears the current selection.

- `bool HasCancelled()`
  Returns `true` if the user has closed the file browser without making a selection.

#### Properties

- `ImGuiFileBrowserFlags Flags { get; set; }`
  Gets or sets the flags used for file browser customization.

- `string Pwd { get; }`
  Gets the current working directory.

- `bool IsOpened { get; }`
  Checks if the file browser window is currently open.

## Enums

### `ImGuiFileBrowserFlags`

Flags for customizing the behavior of the file browser.

- `None`
- `SelectDirectory`
- `EnterNewFilename`
- `NoModal`
- `NoTitleBar`
- `NoStatusBar`
- `CloseOnEsc`
- `CreateNewDir`
- `MultipleSelection`
- `HideRegularFiles`
- `ConfirmOnEnter`

## Usage Example

Below is a simple usage example of how to integrate `imgui-filebrowser.NET` into a MonoGame project:

```csharp
private imFileBrowser fileBrowser;

protected override void Initialize()
{
    // Initialize the file browser
    fileBrowser = new imFileBrowser(ImGuiFileBrowserFlags.None);
    fileBrowser.SetTitle("Select File");
    fileBrowser.SetTypeFilters(new List<string> { "*.png", "*.jpg" });
}

protected override void Update(GameTime gameTime)
{
    if (userRequestedFileBrowser)
    {
        fileBrowser.Open();
    }

    if (fileBrowser.HasSelected())
    {
        Console.WriteLine($"Selected file: {fileBrowser.GetSelected()[0]}");
        fileBrowser.ClearSelected();
    }
}

protected override void Draw(GameTime gameTime)
{
    // Render the file browser
    fileBrowser.Display();
}
```


## Default File Type Colorization

The `imgui-filebrowser.NET` library predefines colors for a variety of file types to enhance visual navigation. Below is a list of file extensions and their associated colors. These colors are applied automatically based on the file's extension:

### Document and Text Files
- `.txt`, `.doc`, `.docx`: Light Grey
- `.pdf`: Red
- `.md`: Orange-Brown

### Image Files
- `.png`, `.jpg`, `.jpeg`: Orange
- `.gif`: Light Green
- `.bmp`: Brown

### Programming and Source Code Files
- `.cs`: Green
- `.cpp`: Teal
- `.py`: Light Blue
- `.java`: Orange-Brown
- `.ts`: Sky Blue

### Audio and Video Files
- `.mp3`: Magenta
- `.wav`: Purple
- `.mp4`: Reddish
- `.avi`: Blue

### Scripting and Configuration Files
- `.sh`: Dark Green
- `.yaml`, `.json`: Dark Orange
- `.ini`: Grey

### Data and Database Files
- `.sql`: Olive Yellow
- `.db`, `.sqlite`: Brownish

### Web and Internet Files
- `.html`: Soft Red
- `.css`: Soft Blue
- `.js`: Yellow
- `.php`: Light Purple

### Multimedia and Design
- `.psd`: Dark Cyan
- `.ai`: Bright Red
- `.fla`: Orange-Yellow
- `.svg`: Turquoise

### Executable and Binary Files
- `.dll`, `.so`: Purple
- `.exe`: Bright Red
- `.bin`: Dark Grey

### Archive Files
- `.zip`, `.rar`, `.7z`: Olive
- `.tar`: Brown

### Engineering and Design
- `.cad`, `.dwg`, `.dxf`: Blue-ish
- `.stl`: Pink-ish

### Science and Data Analysis
- `.pdb`: Gold
- `.csv`: Dark Orange
- `.nc`, `.dat`: Light Blue

### Scripting and Markup Languages
- `.lua`: Green
- `.perl`: Purple
- `.xml`: Soft Red

### Virtual Machine and Container Files
- `.vmdk`, `.ova`: Lavender
- `.dockerfile`: Turquoise

### Miscellaneous
- `.iso`: Yellow
- `.torrent`: Dark Green
- `.vbs`: Purple

### Development and Build Files
- `.makefile`: Brown
- `.cmake`: Slate Blue
- `.docker-compose.yml`: Dark Cyan

### Project Management and Collaboration
- `.ppt`, `.pptx`: Dark Red
- `.xls`, `.xlsx`: Dark Green

These colorizations are designed to make file browsing more intuitive by visually distinguishing file types. Developers can customize these colors or add new associations as needed to tailor the file browser to their application's requirements.

## Type Colorization

Type colorization allows you to customize the appearance of files and directories in the file browser based on their types or extensions. This feature enhances the user experience by making it easier to distinguish between different file types at a glance.

### Setting Colors for File Types

The file browser supports setting specific colors for different file extensions to help users quickly identify file types. This is managed through a dictionary mapping file extensions to colors.

#### Methods for Type Colorization

- `void SetFolderColor(float r, float g, float b, float a)`
  Sets the color for directory entries in the file browser. Colors are specified as RGBA floats ranging from 0 to 1.

- `void SetFileColor(float r, float g, float b, float a)`
  Sets the default color for file entries in the file browser. This color is used for files that do not match any specific extension color rule.

- `void SetTypeColor(string extension, float r, float g, float b, float a)`
  Adds or updates the color associated with a specific file extension. The `extension` parameter should include the dot, e.g., `.txt`.

#### Example

```csharp
// Set a custom color for folders
fileBrowser.SetFolderColor(0.5f, 0.5f, 1.0f, 1.0f); // Light blue

// Set a default file color
fileBrowser.SetFileColor(0.9f, 0.9f, 0.9f, 1.0f); // Almost white

// Set colors for specific file types
fileBrowser.SetTypeColor(".txt", 1.0f, 1.0f, 0.0f, 1.0f); // Yellow for text files
fileBrowser.SetTypeColor(".cs", 0.0f, 1.0f, 0.0f, 1.0f);  // Green for C# source files
```




## Contributing

We welcome contributions to the `imgui-filebrowser.NET` project. Whether it's through submitting bug reports, requesting features, or contributing code, your input is highly appreciated.

To contribute:

1. **Fork** the repository on GitHub.
2. **Clone** the forked repository to your local machine.
3. **Create a new branch** for your feature or fix.
4. **Commit** your changes with clear, descriptive messages.
5. **Push** your branch and changes to your fork on GitHub.
6. **Submit a pull request** to the main `imgui-filebrowser.NET` repository with a clear description of the changes and any relevant issue numbers.

Please ensure your code adheres to the existing style to maintain the project's consistency and readability.

## License

`imgui-filebrowser.NET` is made available under the MIT License. This allows for both personal and commercial use, modification, distribution, and private use, under the conditions that the license and copyright notice are included with any substantial portions of the software.

For the full license text, please see the [LICENSE](LICENSE) file in the repository.

## Acknowledgments

- Thanks to the creators and contributors of [ImGui.NET](https://github.com/mellinoe/ImGui.NET) for the fantastic immediate mode GUI library.
- Thanks to [MonoGame](https://www.monogame.net/) for providing the framework that allows game developers to build amazing games.
- This project uses the great Monogame-ImGui [MonoGame.ImGuiNet](https://github.com/Mezo-hx/MonoGame.ImGuiNet), a fork of another excellent project, as its functional base

## Support

If you encounter any issues or have questions about `imgui-filebrowser.NET`, please feel free to open an issue on the [GitHub issue tracker](https://github.com/tommybear/imgui-filebrowser.NET/issues).
