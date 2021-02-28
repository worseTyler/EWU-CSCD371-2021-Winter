# EWU-CSCD371-2021-Winter

## See [Docs](Docs)

For this assignment we will create a simple time tracking application.
The goal of the application is to allow a user to set a timer to track how long they spend working on various activities.

For this assignment *UNIT TESTING IS NOT NECCISARY* (we will address this dificency next week).

The application is expected to have the following characteristics.

- The main windows should scale up and down nicely. That is the controls on the windows should expand and shink in a reasonable manner as the window size expands and shinks.
- There should be UI elements to handle the following interactions:
  - Start a new timer
  - When a timer is started the UI should update, showing how much time has elapsed
  - Stop the currently running timer
  - Set a description to be associated with the current timer
  - Maintain a list of past timers that shows the description and the durration
  - Past timers should be able to be removed by pressing the delete key

Extra Credit
- Give your app a little bit of flair with a theming library. Two popular options are [Material Design in XAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) and [MahApps](https://github.com/MahApps/MahApps.Metro).
- Add functionality to save and load the time entries. 