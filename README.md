# EasyImageResizeTool
Small program that can easily resize hundreds of images at a time. (Only available for Windows)
## Introduction
While creating and API system that involves lost images, I had realized that there was an easy way to resize the images to a target at the masses. Instead of resizing all of the images one-by-one, I had written this program to automatically do it when large amount of images are passed to it.

## Usage
The program works un-traditionally to other programs. Within the `ResizeInfo` folder, there is `resize_info.txt`. This is where the parameters for the program can be adjusted.

Parameters
<ul>
  <li>Top line - target width (in pixels)</li>
  <li>Middle line - target height (in pixels)</li>
  <li>Bottom line - Quality (This can either be `HIGH` or `LOW`)</li>
</ul>

After the parameters are set, drag all the images you want to resize onto the `EZResizeTool.exe` executable. The processed images will show up in the `Images` folder.

Please read the <a href="#notes">notes</a> for what you should and shouldn't do!

## Notes 📒
<ul id="notes">
  <li>Passing height and width values that are not proportional to the original image dimensions will result in a squished / stretched image.</li>
  <li>I have only tested this program with about 100 images at a time, be careful resizing more than that! (There is no internal limit)</li>
  <li>Only pass image files to the program, other file types will result in errors and crashes. (JPG, JPEG, and PNG ONLY)</li>
  <li>Do not delete any program files or folders! ResizeInfo and resize_info.txt are REQUIRED for the program to run.</li>
  <li>Leaving resize_info.txt blank will crash the program, make sure the paramaters are not empty!</li>
  <li>The code is here if anyone would like to modify the program by any means to suit their specific needs. I do not care what you do with it :) </li>
</ul>
