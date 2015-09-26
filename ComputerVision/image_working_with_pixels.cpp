#include <opencv2/opencv.hpp>

int main(int argc, char** argv) {
	cv::Mat img_rgb = cv::imread("C:\\somepic.jpg");
	cv::Mat img_gry, img_pyr, img_pyr2, img_cny;
	cv::cvtColor(img_rgb, img_gry, cv::COLOR_BGR2GRAY); // to grey
	cv::pyrDown(img_gry, img_pyr); // dec x2
	cv::pyrDown(img_pyr, img_pyr2); // dex x2
	cv::Canny(img_pyr2, img_cny, 10, 100, 3, true); // edges
	cv::namedWindow("Pic1", cv::WINDOW_AUTOSIZE);
	cv::namedWindow("Pic2", cv::WINDOW_AUTOSIZE);
	cv::imshow("Pic1", img_pyr2);
	cv::imshow("Pic2", img_cny);

	// working with pixels
	int x = 16, y = 32;
	cv::Vec3b intensity = img_rgb.at< cv::Vec3b >(y, x);
	uchar blue = intensity.val[0]; // We could write img_rgb.at< cv::Vec3b >(x,y)[0]
	uchar green = intensity.val[1];
	uchar red = intensity.val[2];

	std::cout << "At (x,y) = (" << x << ", " << y <<
		"): (blue, green, red) = (" <<
		(unsigned int)blue <<
		", " << (unsigned int)green << ", " <<
		(unsigned int)red << ")" << std::endl;

	std::cout << "Gray pixel there is: " <<
		(unsigned int)img_gry.at<uchar>(x, y) << std::endl;

	x /= 4; y /= 4;
	std::cout << "Pyramid2 pixel there is: " <<
		(unsigned int)img_pyr2.at<uchar>(x, y) << std::endl;

	img_cny.at<uchar>(x, y) = 128; // Set the Canny pixel there to 128

	cv::waitKey(0);
}