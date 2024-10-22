import requests
from bs4 import BeautifulSoup
import schedule
import time

def scrape_website():
    print(f"Test")  # Check if the request is successful
    url = 'https://www.aftonbladet.se/sok?query=ifk+göteborg'  # Replace with the target URL
    response = requests.get(url)
    print(f"Status Code: {response.status_code}")  # Check if the request is successful
    soup = BeautifulSoup(response.content, 'html.parser')
    
    # Extracting the required information
    articles = soup.find_all('a', class_='searchteaser-root_00e1')
    for article in articles:
        title = article.find('h2', class_='searchteaser-title_00e1').text
        url = article['href']
        image = article.find('img', class_='image-asset')['src']
        content = article.find('span', class_='searchteaser-deck_00e1').text
        
        print(f"Title: {title}")
        print(f"URL: {url}")
        print(f"Image: {image}")
        print(f"Content: {content}")
        print("-" * 80)

def job():
    scrape_website()

# Schedule the job for testing
schedule.every(1).minutes.do(job)

while True:
    schedule.run_pending()
    time.sleep(1)
