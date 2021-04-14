# Egorozh.Razor.Layout
Blazor (Razor) layout based on CSS grid

## Example 
### (Made on the basis https://github.com/tomlm/BlazorCssGrid)
```html
<Grid ColumnDefinitions="auto * auto"
      RowDefinitions="auto * auto"
      ItemMargin="10px"
      Height="100vh">

    <GridChild Column="1"
               BorderColor="pink"
               class="grid-item">
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
              ItemMargin="10px"
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
