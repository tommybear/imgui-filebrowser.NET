# imgui-filebrowser.NET

`imgui-filebrowser.NET` is a highly customizable, easy-to-use file browser for MonoGame applications, leveraging the power of `ImGui.NET`. It is designed to provide developers with a simple yet powerful tool to add file browsing capabilities to their games or tools, with a focus on ease of integration and flexibility.

## Features

- **Single File Integration**: Easy to integrate, with the entire file browser contained in a single `.cs` file.
- **Customizable Appearance**: Offers customizable colors for files, folders, and various file types, enhancing the visual experience.
- **Flexible Browsing Options**: Supports browsing for files, directories, or both, with options for filtering by file type.
- **User Interaction**: Provides functionality for selecting single or multiple files, creating new directories, and more.
- **Adaptable UI**: Allows setting of initial window size, position, and various UI flags for customization.
- **Type Filtering**: Supports filtering visible files by extension, with support for custom type filters.

## Getting Started

To get started with `imgui-filebrowser.NET`, you'll need to have a MonoGame project with `ImGui.NET` set up. If you haven't set up `ImGui.NET` in your project, follow the [ImGui.NET setup instructions](https://github.com/mellinoe/ImGui.NET#usage-with-monogame-and-fna) first.

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

### Flags

The `ImGuiFileBrowserFlags` enum provides flags for customization:

```csharp
[Flags]
public enum ImGuiFileBrowserFlags
{
    None = 0,
    SelectDirectory = 1 << 0,
    EnterNewFilename = 1 << 1,
    // Additional flags...
}
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

## Support

If you encounter any issues or have questions about `imgui-filebrowser.NET`, please feel free to open an issue on the [GitHub issue tracker](https://github.com/tommybear/imgui-filebrowser.NET/issues). We aim to provide support and address issues promptly.

## Changelog

For a detailed history of changes and version updates, refer to the [CHANGELOG.md](CHANGELOG.md) file. We follow semantic versioning to track the changes and improvements made over time.

---

This documentation aims to provide all the necessary information to get started with `imgui-filebrowser.NET`, utilize its features to the fullest, and contribute to its development. We hope this tool significantly enhances your MonoGame project's file browsing capabilities.
