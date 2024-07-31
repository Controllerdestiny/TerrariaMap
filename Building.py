import os
import glob
import shutil
import sys
import zipfile
import urllib.request

def create_zip(source_folder, output_folder, output_filename):
    output_path = os.path.join(output_folder, output_filename)
    with zipfile.ZipFile(output_path, 'w', zipfile.ZIP_DEFLATED) as zipf:
        for root, dirs, files in os.walk(source_folder):
            for file in files:
                zipf.write(os.path.join(root, file), os.path.relpath(os.path.join(root, file), source_folder))

def get_folders(path):
    folders = []
    for entry in os.scandir(path):
        if entry.is_dir():
            folders.append((entry.path, entry.name))
    return folders

if __name__ == '__main__':
    directory_path = "TerrariaMap/bin/Release/net8.0/publish/"
    os.mkdir("out")
    for dir in get_folders(directory_path):
        create_zip(directory_path + dir, "out", dir + ".zip")
    print("打包完成！")
