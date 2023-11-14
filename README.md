# TSGuruClub_CP_Example
Tekla Structures CustomProperty dev example for Estonian Guru Club

Examples are based on E-Betoonelement concrete elements EPD data. Input data is read from text files, WEIGHT report property and PRODUCT_CODE UDA on either mainpart or Cast-Unit modelObject.  
  
Concepts demonstrated in the examples:

* TS CustomProperty code structure
* Get input data from external text file to C# object.
* Get input data from TS model: Mainpart or Assembly (Cast-Unit) level properties/UDAs
* (Use other CP values in next CP)
* Debugging CPs using ExcplicitTesting method (can't use Reload plugins method because CP are not loaded if XS_PLUGIN_DEVELOPER_MODE=TRUE)
* Using CP values in Organizer, reports, drawing templates, model labels, Custom Inqury.
