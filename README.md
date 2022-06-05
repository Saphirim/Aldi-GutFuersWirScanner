# Aldi-GutFuersWirScanner
A very rudimentary bunch of code allowing to quickly scan the QR-codes gifted for shopping at "Aldi", a german discounter, during a special promotion supporting non-profit orgs (https://www.aldi-gutfuerswir.de/).

Code is based on .Net 6 developed using Visual Studio 2022 Community Edition.

To run the solution checkout the repo and insert the Uri-Path individual to your organization to AldiVoter.cs.

This code comes with three major draw-backs:

- The code is bad and nearly untested :(
- Only runs on Windows
- Relies on a closed source / payable QR-scanner library which only works during debug sessions with an IDE attached
