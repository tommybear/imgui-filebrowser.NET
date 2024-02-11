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
3. **Ensure** you have `ImGui.NET` referenced in your project.

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
