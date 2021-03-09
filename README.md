# EWU-CSCD371-2021-Winter

## See [Docs](Docs)

# DUE DATE FOR THIS ASSIGNMENT IS 11:59PM 3/18/2021.

For this assignment we will create a contact app.
The goal of the application is to build a WPF application using the [MVVM design pattern](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel).

The application is expected to do the following.

- Use the MVVM design pattern. As much as possible use data binding and view models and avoid using the code behind (*.xaml.cs).
- The main window should display a list of contacts, the list should be sorted by the contacts name.
- When a contact is selected in the list, display all of contact's information. Any fields that are not specified, should be hidden using style triggers.
- Allow for editing a contact's information. All fields should be visible while editing.
- Allow for create a new contact. 
- Allow for removing a contact.

A contact should have the following data:
- First name
- Last name
- Phone number
- Email address
- Twitter name
- Last modified time (this should be generated and not editable by the user)

Extra Credit
- In addition to the default contact fields, allow for adding an arbitrary set of additional fields.
- App allows for savings and loading contacts using [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#install-entity-framework-core) (simply use SQLite): ✔❌
