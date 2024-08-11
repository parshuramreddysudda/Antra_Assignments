

public static class ApiRequest{
	
    public  static async void RequestAPI(string apiRequestURL){
	    
        var apiClient = new HttpClient{BaseAddress = new Uri(apiRequestURL)};
        var apiRequest = apiClient.GetAsync("/");
        if (apiRequest.IsCompletedSuccessfully)
        {
	        
        }
        
		
											
		
		
    }
}