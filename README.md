# is-My-Music-Complete

## ...But why ?

I got bored, that's why.
... Ok, I got angry seeing that my music library contained incomplete albums, and I wanted to dynamically detect those albums (instead of doing it all manually).


## Set-up

There is just one very small step : Give the path to your music library folder.
You have to change it here :
 ```
 src/Util.cs
 
 change the line 16 (the @ is important) :
  public static string PATH_READ_MUSIC = @"C:\path\to\my\music\library";
 ```


## How to run it
Simply open the project in Visual Studio and run it :)
Or if you have .NET (core) installed, enter *$ dotnet run* in the console at the root of the project's folder.

Depending on the action you perform, a text file containing the according logs will appear in the source folder. 

ENJOY !!
(well, I hope you do)


## It does not f@cking work

Ah. 
To my knowledge, there is only one explanation.
The program supposes that your music is stored as the following :
 ```
 Artist A
  --Album A-1
  ----song A-1-a
  ----song A-1-b
  ----song A-1-c
  
  --Album A-2
  ----song A-2-a
  ----song A-2-b
  ----song A-2-c
  
 Artist B
  --Album B-1
  ----song B-1-a
  ----song B-1-b
  ----song B-1-c
  
  --Album B-2
  ----song B-2-a
  ----song B-2-b
  ----song B-2-c
  
  --Album B-3
  ----song B-3-a
  ----song B-3-b
  ----song B-3-c
 ```
 
 
## Authors

It was made by... me :)
* **BEGEOT Hugues** - [his Git repository](https://github.com/opsilonn)

See also the list of [contributors](https://github.com/opsilonn/s-My-Music-Complete/graphs/contributors) who participated in this project.
