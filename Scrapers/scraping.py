import requests
import schedule
import time

def scrape_website():
    url = 'https://search.service.aftonbladet.se/search?query=ifk+g%C3%B6teborg&type=&sort=score&filter=any&pageSize=5&page=1'
    
    response = requests.get(url)
    print(f"Status Code: {response.status_code}")  # Check if request is successful
    
    if response.status_code != 200:
        print("Failed to retrieve the page")
        return
    
    data = response.json()  # Parse the JSON response
    
    # Extract articles
    for result in data['results']:
        if result['result'] == 'articles':
            print("Articles:")
            for item in result['items']:
                title = item['title']
                article_url = item['url']
                published_date = item['publishedDate']
                section_title = item['sectionTitle']
                
                print(f"Title: {title}")
                print(f"URL: {article_url}")
                print(f"Published Date: {published_date}")
                print(f"Section: {section_title}")
                print("-" * 80)
        
        elif result['result'] == 'videos':
            print("Videos:")
            for item in result['items']:
                title = item['title']
                video_url = item['url']
                image_url = item['image']
                duration = item['duration']
                published_date = item['publishedDate']
                section_title = item['sectionTitle']
                
                print(f"Title: {title}")
                print(f"URL: {video_url}")
                print(f"Image: {image_url}")
                print(f"Duration: {duration}")
                print(f"Published Date: {published_date}")
                print(f"Section: {section_title}")
                print("-" * 80)

def job():
    scrape_website()

# Schedule the job for testing
schedule.every(1).minutes.do(job)

while True:
    schedule.run_pending()
    time.sleep(1)

