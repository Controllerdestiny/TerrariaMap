import os
import glob
import shutil
import sys
import zipfile
import urllib.request

def zip_files_in_folder(folder_path, zip_file_path):
    with zipfile.ZipFile(zip_file_path, 'w') as zipf:
        for foldername, subfolders, filenames in os.walk(folder_path):
            for filename in filenames:
                file_path = os.path.join(foldername, filename)
                zipf.write(file_path, arcname=os.path.basename(file_path))
    print(f"📦 压缩包已生成: {zip_file_path}")
    
if __name__ == '__main__':
    build_name = sys.argv[1]
    print(build_name)
    directory_path = "TerrariaMap/bin/Release/net8.0/publish/"
    zip_files_in_folder(directory_path + build_name, "TerrariaMap_" + build_name + "_8.0.zip")
