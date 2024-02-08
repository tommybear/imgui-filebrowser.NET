using ImGuiNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Monogame.ImGuiNet.Utils;

public class ImGuiFileBrowser
{
    private Vector2 _windowSize = new Vector2(700, 450);
    private string _title = "File Browser";
    private bool _isOpen = false;
    private string _currentPath = Directory.GetCurrentDirectory();
    private List<string> _files = new List<string>();
    private HashSet<string> _selectedFiles = new HashSet<string>();
    private List<string> _filters = new List<string> { "*.*" }; // Default filter
    private int _currentFilterIndex = 0;
    private bool _allowMultipleSelection = false;
    private ImGuiFileBrowserFlags _flags;

    public ImGuiFileBrowser(ImGuiFileBrowserFlags flags = ImGuiFileBrowserFlags.None)
    {
        _flags = flags;
    }

    public void Open()
    {
        _isOpen = true;
        UpdateFileList();
    }

    public void Close()
    {
        _isOpen = false;
    }

    public bool IsOpen() => _isOpen;

    public void Display()
    {
        if (!_isOpen)
            return;

        if ((_flags & ImGuiFileBrowserFlags.NoModal) == ImGuiFileBrowserFlags.NoModal)
        {
            ImGui.Begin(_title, ref _isOpen, ImGuiWindowFlags.NoResize);
        }
        else
        {
            ImGui.OpenPopup(_title);
            if (!ImGui.BeginPopupModal(_title, ref _isOpen, ImGuiWindowFlags.NoResize))
            {
                return;
            }
        }

        if (ImGui.Button("Up"))
        {
            var parentDir = Directory.GetParent(_currentPath)?.FullName;
            if (parentDir != null)
            {
                _currentPath = parentDir;
                UpdateFileList();
            }
        }

        ImGui.SameLine();
        ImGui.Text($"Current Path: {_currentPath}");

        if (ImGui.BeginListBox("Files", -Vector2.One))
        {
            foreach (var file in _files)
            {
                bool isSelected = _selectedFiles.Contains(file);
                if (ImGui.Selectable(file + (Directory.Exists(Path.Combine(_currentPath, file)) ? "/" : ""), isSelected))
                {
                    if ((_flags & ImGuiFileBrowserFlags.MultipleSelection) == ImGuiFileBrowserFlags.MultipleSelection)
                    {
                        if (!isSelected)
                        {
                            _selectedFiles.Add(file);
                        }
                        else
                        {
                            _selectedFiles.Remove(file);
                        }
                    }
                    else
                    {
                        _selectedFiles.Clear();
                        _selectedFiles.Add(file);
                    }
                }
            }
            ImGui.EndListBox();
        }

        // Footer area for additional controls or information display
        ImGui.Text($"{_selectedFiles.Count} items selected");

        if (ImGui.Button("Open") && _selectedFiles.Count > 0)
        {
            // Handle file(s) opening
            Close();
        }

        ImGui.SameLine();

        if (ImGui.Button("Cancel"))
        {
            Close();
        }

        if ((_flags & ImGuiFileBrowserFlags.NoModal) == ImGuiFileBrowserFlags.NoModal)
        {
            ImGui.End();
        }
        else
        {
            ImGui.EndPopup();
        }
    }

    private void UpdateFileList()
    {
        _files.Clear();
        var directories = Directory.GetDirectories(_currentPath);
        var files = Directory.GetFiles(_currentPath);

        _files.AddRange(directories.Select(Path.GetFileName));
        _files.AddRange(files.Select(Path.GetFileName));

        if (_currentFilterIndex < _filters.Count && _filters[_currentFilterIndex] != "*.*")
        {
            _files = _files.Where(f => _filters[_currentFilterIndex] == Path.GetExtension(f) || Directory.Exists(Path.Combine(_currentPath, f))).ToList();
        }
    }

    // Additional functionalities like SetTitle, SetWindowSize, SetWindowPos, filters, etc., can be implemented here.
}

[Flags]
public enum ImGuiFileBrowserFlags
{
    None = 0,
    SelectDirectory = 1 << 0,
    EnterNewFilename = 1 << 1,
    NoModal = 1 << 2,
    NoTitleBar = 1 << 3,
    NoStatusBar = 1 << 4,
    CloseOnEsc = 1 << 5,
    CreateNewDir = 1 << 6,
    MultipleSelection = 1 << 7,
    HideRegularFiles = 1 << 8,
    ConfirmOnEnter = 1 << 9,
}
