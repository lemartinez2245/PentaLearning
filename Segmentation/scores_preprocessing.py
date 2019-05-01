from cv2 import *
import sys


def to_binary(image, threshold):
    for i in range(len(image)):
        for j in range(len(image[i])):
            if image[i, j] >= threshold:
                image[i, j] = 255
            else:
                image[i, j] = 0
    return image


def get_hlines_from_edges(edges, threshold):
    hlines = []
    first_line = False
    for i, line in enumerate(edges):
        # print(line)
        count = countNonZero(line.ravel())
        # count = len(line)
        # print(line)
        if count >= threshold and not first_line:
            hlines.append([i, -1, count, -1])
            first_line = True
        elif count >= threshold:
            hlines[-1][1] = i
            hlines[-1][3] = count
            first_line = False
    return hlines


def process(file_name):
    image = imread(file_name)

    # if len(sys.argv) >= 2:
    #    image = resize(image, (int(image.shape[0]*(sys.argv[1] / 100)), int(image.shape[1]*(sys.argv[1] / 100))))

    gray = cvtColor(image, COLOR_BGR2GRAY)
    binary = to_binary(gray, 128)
    blurry = GaussianBlur(binary, (5, 5), 0)
    canned = Canny(blurry, 50, 200)

    # region Contour detection approach
    contours, _ = findContours(canned, RETR_EXTERNAL, CHAIN_APPROX_NONE)

    horizontal_lines = get_hlines_from_edges(canned, image.shape[0]-image.shape[0]/3)

    if len(horizontal_lines) % 5 == 0 and len(horizontal_lines) > 0:
        print("Staff Lines Correctly Recognized")
    else:
        print(len(horizontal_lines))
        for i in range(len(horizontal_lines)):
            for j in range(len(horizontal_lines[i])):
                if horizontal_lines[i][j]:
                    image[i, j] = (0, 0, 255)
        imshow("Lines detected", image)
        waitKey(0)
        raise Exception("Error in the Lines Recognition!!!")

    lines_thickness = horizontal_lines[0][1] - horizontal_lines[0][0]
    lines_distance = (horizontal_lines[1][0] - horizontal_lines[0][1] + horizontal_lines[2][1])

    for i in range(len(horizontal_lines)):
        for row_index in range(1, horizontal_lines[i][1] - horizontal_lines[i][0]):
            for column in range(1, len(binary[row_index])-1):
                if (binary[horizontal_lines[i][0]-1, column] == 255 or binary[horizontal_lines[i][1], column] == 255)\
                        and (binary[horizontal_lines[i][0]-1, column-1] == 255
                            or binary[horizontal_lines[i][1], column+1] == 255)\
                        and (binary[horizontal_lines[i][0]-1, column+1] == 255
                            or binary[horizontal_lines[i][1], column-1] == 255):
                    gray[horizontal_lines[i][0] + row_index, column] = 255
                else:
                    gray[horizontal_lines[i][0] + row_index, column] = \
                        (int((int(gray[horizontal_lines[i][0] + row_index - 1, column - 1]) +
                            gray[horizontal_lines[i][0] + row_index - 1, column] +
                            gray[horizontal_lines[i][0] + row_index - 1, column + 1] +
                            gray[horizontal_lines[i][1] + row_index, column - 1] +
                            (gray[horizontal_lines[i][0] + row_index, column] * 8) +
                            gray[horizontal_lines[i][1] + row_index, column + 1] +
                            gray[horizontal_lines[i][1] + row_index + 1, column - 1] +
                            gray[horizontal_lines[i][1] + row_index + 1, column] +
                            gray[horizontal_lines[i][1] + row_index + 1, column + 1])/9 / 128)*255)

    # endregion

    # imshow("Original", image)

    # imshow("Lines Substraction", gray)

    # waitKey(0)

    imwrite("no lines.png", gray)
