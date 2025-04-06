import requests

def csv_download():
    url = 'https://compucore.itcarlow.ie/Microbial_Mayhem_Analytics/download_csv'
    
    # Download CSV
    response = requests.get(url)
    
    if response.status_code == 200:
        # Save the file locally
        with open('downloaded_data.csv', 'wb') as file:
            file.write(response.content)
        print("CSV downloaded successfully. Saved as 'downloaded_data.csv'.")
    else:
        print(f"Failed to download CSV. Status code: {response.status_code}")

csv_download()
