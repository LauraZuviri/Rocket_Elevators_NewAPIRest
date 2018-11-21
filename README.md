# Rocket_Elevators_-.NET
Contains the files for the Rocket Elevators Solutions for C#


## Endpoints
**GET /api/leads**
<br />
*Returns all leads in the last 30 days*

**GET /api/elevators**
<br />
*Returns all elevators*
<br />
**GET /api/elevators/status**
<br />
*Returns all elevators that has a status of inactive or intervention*
<br />
**GET /api/elevator/{elevatorid}**
<br />
*Returns one elevator status*
<br />
**PUT /api/elevator/{elevatorid}?value=status**
<br />
*Changes the selected elevator status to the value*

**GET /api/columns**
<br />
*Returns all columns*
<br />
**GET /api/column/{columnid}**
<br />
*Returns one column status*
<br />
**PUT /api/column/{columnid}?value=status**
<br />
*Changes the selected column status to the value*

**GET /api/buildings**
<br />
*Returns all buildings that has atleast one elevator, column or one battery that is in intervention*

**GET /api/batteries**
<br />
*Returns all batteries*
<br />
**GET /api/battery/{batteryid}**
<br />
*Returns one battery status*
<br />
**PUT /api/battery/{batteryid}?value=status**
<br />
*Changes the selected battery status to the value*



** 3 NEW END POINTS
<br />
**GET /api/intervention/status**
<br />
*Return all the interventions that don't have a "start date" and which status is "Pending".
<br />
**PUT /api/intervention/Inprogress/{interventionid}**
<br />
*Change one intervention status from "Pending" to "In progress" and add a "Start date" to it.
**PUT /api/intervention/Completed/{interventionid}**
<br />
*Change one intervention status from "In progress" to "Completed" and add a "End date" to it.


