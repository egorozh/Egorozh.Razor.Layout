[![Nuget](https://img.shields.io/nuget/v/Egorozh.Razor.Layout?label=Egorozh.Razor.Layout)](https://www.nuget.org/packages/Egorozh.Razor.Layout/)

# Egorozh.Razor.Layout
Blazor (Razor) layout based on CSS grid

## Getting Started

Install the library as a NuGet package:
```powershell
Install-Package Egorozh.Razor.Layout
# Or 'dotnet add package Egorozh.Razor.Layout'
```
Then, add using in _Imports.razor:
```razor
@using Egorozh.Razor.Layout
```

## Example 
(Made on the basis https://github.com/tomlm/BlazorCssGrid)
```razor
<Grid ColumnDefinitions="auto * auto"
      RowDefinitions="auto * auto"
      ItemGap="10px"
      Height="100vh">

    <GridChild Column="1"
               class="grid-item"
               style="border-color: pink">
        Row 1 Col 1
    </GridChild>
    <GridChild Column="2"
               BorderColor="red"
               class="grid-item">
        Row 1 Col 2
    </GridChild>
    <GridChild Column="3"
               BorderColor="blue"
               class="grid-item">
        Row 1 Col 3
    </GridChild>

    <GridChild Row="2"
               Column="1"
               ColumnSpan="3">
        <Grid ColumnDefinitions="auto * auto"
              ItemGap="10px"
              style="border-style: solid; padding: 10px; border-color: chartreuse;">

            <GridChild Column="1"
                       style="background-color: darksalmon; padding: 10px;">
                @for (int i = 0; i < 1000; i++)
                {
                    <p>This GridItem is cropped @i.</p>
                }
            </GridChild>

            <GridChild Column="2"
                       VerticalScrollBar="ScrollBar.Auto"
                       style="background-color: darkseagreen">
                @for (int i = 0; i < 1000; i++)
                {
                    <p>This GridItem should scroll @i.</p>
                }
            </GridChild>

            <GridChild Column="3"
                       style="background-color: darkturquoise">
                @Body
            </GridChild>

        </Grid>
    </GridChild>

    <GridChild Row="3" Column="1"
               BorderColor="black"
               class="grid-item">
        Row 3 Col 1
    </GridChild>
    <GridChild Row="3" Column="2"
               ColumnSpan="2"
               BorderColor="purple"
               class="grid-item">
        Row 3 Col 2/3
    </GridChild>

</Grid>
```
![screenshot.png](https://github.com/egorozh/Egorozh.Razor.Layout/blob/master/screenshot.png)
