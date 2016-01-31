# ken.Speech
---

Using a speech engine to help me repeat polish words. 

Especially those numbers that I always mix up when writing down on paper.

## Glossary

* TTS : Text to speech
* SR : Speech recognition

## Downloads

* **Speech Platform**: [https://www.microsoft.com/en-us/download/details.aspx?id=27225](https://www.microsoft.com/en-us/download/details.aspx?id=27225)
* **Runtime Languages**: [https://www.microsoft.com/en-us/download/details.aspx?id=27224](https://www.microsoft.com/en-us/download/details.aspx?id=27224)
* **Language Packs**: [http://windows.microsoft.com/en-us/windows/language-packs](http://windows.microsoft.com/en-us/windows/language-packs)

## Things to remember

* Microsoft.Speech vs System.Speech
* You can copy language packs registry settings
* It seems that Microsoft.Speech needs net4.0 or you get "Retrieving the COM class factory for component with CLSID {49428A60-C997-4D0E-9808-9E326C178D58} failed due to the following error: 80040154 Class not registered (Exception from HRESULT: 0x80040154 (REGDB_E_CLASSNOTREG))." 

## Share packs between spaces

* Under - HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech Server\v11.0\Voices - right click the "Tokens" folder and export.
* Under - HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Speech Server\v11.0\Voices - right click "Tokens" and again export it.
* Replace \Speech Server\v11.0\ into \Speech\ into for both exported files.
* double click to "run" both files to import into registry.

## Workload

* Hard to get correct engine working, because documentation is not clear about the differce between namespaces.
* Grammer differences
 