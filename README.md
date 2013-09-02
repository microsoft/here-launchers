HERE Launchers
==============

This project is hosting the HERE Launchers API library and source codes, as well
as the demo application illustrating the use of the API.

Getting started
-------------------------------------------------------------------------------

The documentation for the API is located at Nokia Lumia Developer's Library
(http://www.developer.nokia.com/Resources/Library/Lumia/#!maps-and-navigation/here-launchers.html).

Full source code for the demo project as well as the DLL can be found in the
repository. All projects are designed to be built with normal Windows Phone 8
SDK. More information on how to get started can be found in the wiki:
https://github.com/nokia-developer/here-launchers/wiki

Demo project
-------------------------------------------------------------------------------

The structure of the demo application is really simple. When launched, you first
see the start screen as shown above. In this view you can simply start the
different views used to demonstrate the usage of different functionalities
provided by the HERE Launchers API.

In each view, you can fill in the required fields and then press the button
located at the bottom of the view to launch the handler application for the
functionality.

Special input handling is implemented for each location (latitude/longitude)
input box, they accept input only as described below:

* '-' character can only be input as first character (long press of comma/dot
  button brings options for inputting minus sign).
* There can be only one decimal separator character.
* The separator character added to the input box is taken from locate settings.
* In input, both ',' and '.' characters are accepted as decimal separators.
* Invalid value is shown in red color. 

Additionally, there is a location selection view which can be opened by pressing
the "Get" button located on the right side of the views.

When pressing "Ok" in the location selection, the location in which the yellow
dot marker is will be set as the selected location; pressing "Cancel" will
cancel the location selecting.

When the dot in upper right corner of the map is green, then clicking it will
move the map center to the location determined with the positioning API. The
accuracy of the position will be shown with a green circle polygon drawn into
the map.

The yellow dot marker can be moved by dragging it with finger; also when it is
not shown in the visible area of the map, you can move it to selected location
by tapping the map view.

Locations can also be found by using the Geocoding service. If there are
multiple results for the query, then there will be a selection list located in
the upper side of the map view. The yellow dot marker will be moved to the
selected location once a result from the list is selected.
