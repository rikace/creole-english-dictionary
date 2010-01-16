
CrisisCamp Haiti
01/16/2009

CONTACT INFORMATION
David M. Mroz           dave.mroz@glimmernet.com                Glimmernet Technologies 301-591-4373x22
Riccardo Scannicchio    riccardo.scannicchio@glimmernet.com     Glimmernet Technologies 301-591-4373x19
Michael Mendelson       mmendelson@gmail.com    

OVERVIEW

This project is a simple dictionary lookup for Creole to English. 

This code is not meant to be a world-class tranlation tool, but was a start at a simple dictionary-based
word-for-word translator to aid other developers, project managers, and interested parties in the basic translations
of Creole to English and vice-versa.

The application works by parsing input strings into a string array and then iterating through an XML-based dictionary to perform the translations. 

Admittedly the approach is somewhat limited in the fact that it assumes a one-to-one translation for each word.  More accurately, the XML dictionary file supports multiple translations, but the code automatically assumes that the first entry in the list is the correct (and only) translation.  Hopefully future developers can extend the code to add context-sensitive translation.

Future developers need to be aware of the fact that  the ordering of words in the dictionary is very important in the searching algorithm since there is no content-weighting for the translation.  Second, the accent marks in the Creole language required some special byte-comparisons and replacements.  If you find that words are not being translated, investigate this block of code in the translate.cs file.

If you have any questions, please do not hesitate to contact any of us at the email addresses above – we’d be happy to continue helping and to help take this project to the next level.

Lastly, there are many more people that contributed to this – especially in proving linguistics support for the Creole language.  Thanks to everyone who is not listed in here particularly Luc, Christine, and Greg who all worked very hard at CrisisCamp today.






